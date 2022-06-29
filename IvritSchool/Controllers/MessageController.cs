using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IvritSchool.BLL.Users;
using IvritSchool.Commands;
using Telegram.Bot;
using Telegram.Bot.Types;
using IvritSchool.StateMachine;

namespace IvritSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IEnumerable<Command> _commands;
        private readonly IBotStateMachine _stateMachine;
        public MessageController(IUserBLL userBLL,
                                 IEnumerable<Command> commands,
                                 IBotStateMachine stateMachine)
        {
            _userBLL = userBLL;
            _commands = commands;
            _stateMachine = stateMachine;
        }

        [HttpPost]
        [Route("update")]
        public async Task<OkResult> Update([FromForm] Update update)
        {
            TelegramBotClient botClient = await Bot.Bot.Get();

            var Data = await GetInformationFromUpdate(update, botClient);
            long TId = Data.Item2;
            string Text = Data.Item1;

            if (_userBLL.IsBanned(TId))
            {
                await botClient.SendTextMessageAsync(TId, "вы забанены!");
                return Ok();
            }

            try
            {
                foreach (var el in _commands)
                {
                    if (el.Contains(Text))
                    {
                        await el.ExecuteAsync(update, botClient);
                        return Ok();
                    }
                }

                var user = _userBLL.GetByTID(TId);

                if(user == null)
                {
                    return Ok();
                }

                await _stateMachine.Execute(user, update.Message, botClient, TId);

            }
            catch (Exception ex)
            {
                await botClient.SendTextMessageAsync(322044387, ex.ToString());
            }

            return Ok();
        }

        public static async Task<(string, long)> GetInformationFromUpdate(Update updatee, TelegramBotClient client)
        {
            Message message;
            var update = updatee;
            string Text = "";
            long TId = 0;
            try
            {
                if (update.CallbackQuery?.Data != null || update.Message?.Text != null)
                {
                    Text = update.CallbackQuery == null ? update.Message.Text : update.CallbackQuery.Data;
                }

                if (update.CallbackQuery != null)
                {
                    TId = update.CallbackQuery.From.Id;
                }
                else if (update.Message != null)
                {
                    message = update.Message;
                    TId = message.From.Id;
                }
                Console.WriteLine(Text);
                return (Text, TId);
            }
            catch (Exception ex)
            {
                await client.SendTextMessageAsync(322044387, ex.ToString());
                return ("", 0);
            }
        }
    }
}
