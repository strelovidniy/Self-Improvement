using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface ITelegramBotService
    {
        public void StartCommandAsync(Update update, bool autorized);
    }
}