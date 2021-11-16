using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class TelegramHandlersService : ITelegraHandlersService
    {
        #region Private Fields

        private readonly ILogger<TelegramHandlersService> _logger;
        private readonly TelegramService _tgService;

        #endregion

        #region Constructors

        public TelegramHandlersService(TelegramService tgService, ILogger<TelegramHandlersService> logger)
        {
            _tgService = tgService;
            _logger = logger;
        }

        #endregion
        
        #region ITelegraHandlersService Implementation

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _                                       => exception.ToString()
            };
            
            _logger.LogError("Telegram API Error:{0}", errorMessage);
            
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
                return;
            if (update.Message.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text:   $"Received a '{update.Message.Text}' message in chat {chatId}."
            );
        }

        #endregion
    }
}