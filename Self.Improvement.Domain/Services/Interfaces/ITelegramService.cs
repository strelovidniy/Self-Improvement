using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface ITelegramService
    {
        public Task<Message> SendMessageAsync(ChatId chatId, string message);
    }
}
