using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders.MessageTypes
{
    public interface IMessage
    {
        Task SendAsync(Entities.Message message, TelegramBotClient client, long tid);
    }
}
