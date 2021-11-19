using Self.Improvement.Domain.Services.Interfaces;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class BotCommandsService : IBotCommandsService
    {
        private readonly ITelegramBotService _tgService;
        private bool isAuthorized = false;
        
        public BotCommand StartCommand { get; set; }

        public BotCommandsService(ITelegramBotService tgService)
        {
            _tgService = tgService;
        }
        
        public void InitCommands()
        {
            StartCommand = new BotCommand
            {
                Command = "/start",
                Description = "command to start the bot"
            };
        }

        public void HandleCommands(Update update)
        {
            if (update.Message.Text == StartCommand.Command)
            {
                _tgService.startCommand(update, false);
            }
        }
    }
}