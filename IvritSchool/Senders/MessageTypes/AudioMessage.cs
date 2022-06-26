using IvritSchool.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders.MessageTypes
{
    public class AudioMessage : IMessage
    {
        public async Task SendAsync(Message message, TelegramBotClient client, long tid)
        {
            await client.SendAudioAsync(tid, $"{Bot.AppSettings.baseUrl}/{message.Path}", protectContent:true);
        }
    }
}
