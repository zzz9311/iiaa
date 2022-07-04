using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Enums;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace IvritSchool.Commands
{
    public class HelloCommand : Command
    {
        private readonly IUserBLL _userBLL;
        public HelloCommand(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        public override string Name => "/start";

        public override async Task ExecuteAsync(Update message, TelegramBotClient client)
        {
            var user = _userBLL.GetByTID(message.Message.From.Id);

            if (user == null)
            {
                user = new BotUser()
                {
                    TID = message.Message.From.Id,
                    IsBanned = false,
                    Status = UserStatus.None,
                    FirstDate = DateTime.Now,
                    Name = message.Message.From.Username
                };

                _userBLL.Add(user);
            }

            var inlineSelect = new InlineKeyboardMarkup(new[]
            {
                                            new[]
                                            {
                                                InlineKeyboardButton.WithCallbackData("Найти оплату","Найти оплату"),
                                            }
            });
            await client.SendTextMessageAsync(user.TID, "Приветственное сообщение",replyMarkup: inlineSelect);
        }
    }
}
