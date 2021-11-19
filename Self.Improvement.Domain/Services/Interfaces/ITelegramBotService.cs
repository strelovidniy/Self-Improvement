using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface ITelegramBotService
    {
        public void Authenticate(Update update);
    }
}