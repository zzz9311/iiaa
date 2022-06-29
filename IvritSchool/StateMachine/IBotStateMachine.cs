using IvritSchool.Entities;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.StateMachine
{
    public interface IBotStateMachine
    {
        Task Execute(BotUser user, Telegram.Bot.Types.Message message, TelegramBotClient client, long tid);
    }
}