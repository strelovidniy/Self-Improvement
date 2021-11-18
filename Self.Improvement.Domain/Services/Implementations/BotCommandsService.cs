using Self.Improvement.Domain.Services.Interfaces;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class BotCommandsService : IBotCommandsService
    {
        public BotCommand StartCommand { get; set; }

        public void InitCommands()
        {
            StartCommand = new BotCommand
            {
                Command = "start",
                Description = "command to start the bot"
            };
        }
    }
}