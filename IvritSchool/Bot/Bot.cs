using IvritSchool.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telegram.Bot;

namespace IvritSchool.Bot
{
    public static class Bot
    {
        private static TelegramBotClient client;

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            client = new TelegramBotClient(AppSettings.Key);

            string url = string.Format(AppSettings.Url, "message/update");
            await client.SetWebhookAsync(url);
            return client;
        }
    }
}