using IvritSchool.Enums;
using IvritSchool.Senders.MessageTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders
{
    public class Sender
    {
        public async Task SendMessage(Entities.Message message, long tid, TelegramBotClient client)
        {
            var messageType = GetMessageType(message.Type);
            await messageType.SendAsync(message, client, tid);
        }

        private IMessage GetMessageType(MessageType type)
        {
            switch (type)
            {
                case MessageType.Text:
                    {
                        return new TextMessage();
                    }
                case MessageType.Audio:
                    {
                        return new AudioMessage();
                    }
                case MessageType.Video:
                    {
                        return new VideoMessage();
                    }
            }

            throw new ArgumentNullException("Sender = null");
        }
    }
}
