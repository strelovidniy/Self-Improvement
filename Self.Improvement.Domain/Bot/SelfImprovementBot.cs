using System;
using Telegram.Bot;

namespace Bot
{
    class SelfImprovementBot
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("2137745577:AAE4XONfwYQ9gLwDQbp_Y9jSeJoylLj8-fw");
            var me = botClient.GetMeAsync();
            Console.WriteLine(
                $"Hello, World! I am user {me.Id}"
            );
        }
    }
}
