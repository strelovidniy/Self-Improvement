using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly IBotCommandsService _botCommands;
        private readonly ChatBot _tgBot;
        private readonly IOptions<ChatBotConfig> _accessToken;

        public TelegramBotService(IBotCommandsService botCommands, ChatBot tgBot, IOptions<ChatBotConfig> accessToken)
        {
            _botCommands = botCommands;
            _botCommands.InitCommands();
            _accessToken = accessToken;
            _tgBot = tgBot;
            _tgBot.Init(_accessToken.Value.AccessToken);
        }
        
        public async void Authenticate(Update update)
        {
            if (update.Message != null)
            {
                await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "What`s your name?");
                var name = update.Message.Text;
                await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, $"Your name is {name}?");
            }
        }
    }
}