using IvritSchool.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders.MessageTypes
{
    public class PhotoMessage : IMessage
    {
        public async Task SendAsync(Message message, TelegramBotClient client, long tid)
        {
            await client.SendPhotoAsync(tid, $"{Bot.AppSettings.baseUrl}/{message.Path}");
        }
    }
}
