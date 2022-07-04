using IvritSchool.BLL.PayedUsers;
using IvritSchool.BLL.Users;
using IvritSchool.Entities;
using IvritSchool.Enums;
using IvritSchool.Enums.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Message = Telegram.Bot.Types.Message;

namespace IvritSchool.StateMachine
{
    public class BotStateMachine : IBotStateMachine
    {
        private readonly IPayedUser _payedUserBLL;
        private readonly IUserBLL _userBLL;
        public BotStateMachine(IPayedUser payedUserBLL,
            IUserBLL userBLL)
        {
            _payedUserBLL = payedUserBLL;
            _userBLL = userBLL;
        }
        public async Task Execute(BotUser user, Message message, TelegramBotClient client, long tid)
        {
            switch (user.Status)
            {
                case UserStatus.None:
                    {
                        return;
                    }
                case UserStatus.FindEmail:
                    {
                        var email = message.Text;

                        var result = _payedUserBLL.SetUser(tid, email);

                        if (result == SetPayedUserStatus.IsUsing)
                        {
                            await client.SendTextMessageAsync(tid, "Почта занята");
                        }
                        else if(result == SetPayedUserStatus.NotFound)
                        {
                            await client.SendTextMessageAsync(tid, "Почта не найдена");
                        }
                        else
                        {
                            await client.SendTextMessageAsync(tid, "Почта найдена");
                        }

                        _userBLL.SetStaus(tid, UserStatus.None);
                    }
                    break;
            }
        }
    }
}
