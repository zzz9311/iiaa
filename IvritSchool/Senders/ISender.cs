using IvritSchool.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Senders
{
    public interface ISender
    {
        Task SendMessage(Message message, long tid, TelegramBotClient client);
    }
}