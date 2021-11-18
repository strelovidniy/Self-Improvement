using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IBotCommandsService
    {
        public BotCommand StartCommand { get; set; }
        public void InitCommands();
    }
}