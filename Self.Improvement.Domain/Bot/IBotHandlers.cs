using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Bot
{
    public interface IBotHandlers
    {
        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
            CancellationToken cancellationToken);
        
        public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken);
    }
}