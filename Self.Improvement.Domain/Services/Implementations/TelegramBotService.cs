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
                var startMessageId = update.Message.MessageId;
                await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "What`s your name?");
                string name = "";
                string email;
                if (update.Message.MessageId != startMessageId)
                {
                    name = update.Message.Text;
                    await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, $"Ok, {name}, what is you email?");
                    if (update.Message.Text != name)
                    {
                        email = update.Message.Text;
                        await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, $"Thank you, you are now registered!");
                    }
                }

                
            }
        }
    }
}