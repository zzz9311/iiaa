using IvritSchool.Entities;
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
    public class Sender : ISender
    {
        public async Task SendMessage(Message message, long tid, TelegramBotClient client)
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
                case MessageType.Photo:
                    {
                        return new PhotoMessage();
                    }
                case MessageType.Forward:
                    {
                        return new ForwardMessageType();
                    }
            }
            throw new ArgumentNullException("Sender = null");
        }
    }
}


