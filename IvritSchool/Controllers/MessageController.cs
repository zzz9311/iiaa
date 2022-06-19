using IvritSchool.BLL.Users;
using IvritSchool.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace IvritSchool.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserBLL _userBLL;
        private readonly IEnumerable<Command> _commands;
        public MessageController(IUserBLL userBLL, 
                                 IEnumerable<Command> commands)
        {
            _userBLL = userBLL;
            _commands = commands;
        }
        [HttpPost]
        [Route("message/update")]
        public async Task<OkResult> Update([FromBody] Update update)
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
            }
            catch (Exception)
            {
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
