using IvritSchool.BLL.Users;
using IvritSchool.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace IvritSchool.Commands
{
    public class CheckIfPayed : Command
    {
        private readonly IUserBLL _userBLL;
        public CheckIfPayed(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        public override string Name => "Найти оплату";

        public async override Task ExecuteAsync(Update message, TelegramBotClient client)
        {
            await client.AnswerCallbackQueryAsync(message.CallbackQuery.Id);
            _userBLL.SetStaus(message.CallbackQuery.From.Id, UserStatus.FindEmail);
            await client.SendTextMessageAsync(message.CallbackQuery.From.Id, "Введите почту к которой привязана оплата");
        }
    }
}
