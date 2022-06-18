using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace IvritSchool.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task ExecuteAsync(Update message, TelegramBotClient client);

        public bool Contains(string message)
        {
            return message.ToLower().Contains(Name.ToLower());
        }
    }
}