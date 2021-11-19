using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface ITelegramBotService
    {
        public void startCommand(Update update, bool autorized);
    }
}