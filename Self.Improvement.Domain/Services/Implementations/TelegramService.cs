using System.Threading.Tasks;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class TelegramService : ITelegramService
    {
        private readonly ChatBot _bot;

        public TelegramService(ChatBot bot)
        {
            _bot = bot;
        }

        public async Task<Message> SendMessageAsync(ChatId chatId, string message)
        {
            var description = await _bot.Client.SendTextMessageAsync(chatId, message);

            return description;
        }
    }
}
