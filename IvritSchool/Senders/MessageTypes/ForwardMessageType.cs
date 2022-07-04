using IvritSchool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders.MessageTypes
{
    public class ForwardMessageType : IMessage
    {
        public async Task SendAsync(Message message, TelegramBotClient client, long tid)
        {
            await client.ForwardMessageAsync(tid, message.ForwardedGroup, message.ForwardedMessage, protectContent: true);
        }
    }
}
