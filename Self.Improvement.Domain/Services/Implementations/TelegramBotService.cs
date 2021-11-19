using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class TelegramBotService : ITelegramBotService
    {
        private readonly ChatBot _tgBot;
        private readonly IOptions<ChatBotConfig> _accessToken;

        public TelegramBotService(ChatBot tgBot, IOptions<ChatBotConfig> accessToken)
        {
            _accessToken = accessToken;
            _tgBot = tgBot;
            _tgBot.Init(_accessToken.Value.AccessToken);
        }
        
        public async void startCommand(Update update, bool authorized)
        {
            await _tgBot.Client.SendTextMessageAsync(update.Message!.Chat.Id, "Hello");
            if (!authorized)
            {
                await _tgBot.Client.SendTextMessageAsync(update.Message!.Chat.Id, "What`s your name?");
            }
            else
            {
                await welcomeBack(update);
            }
        }

        public async Task welcomeBack(Update update)
        {
            var specialistButton = new KeyboardButton("Specialist");
            var goalsButton = new KeyboardButton("Goals");
            
            var buttonsList = new List<KeyboardButton>();
            
            buttonsList.Add(specialistButton);
            buttonsList.Add(goalsButton);
            
            var keyboard = new ReplyKeyboardMarkup(buttonsList)
            {
                ResizeKeyboard = true
            };

            await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "Welcome back, choose what you gonna do!", replyMarkup: keyboard);
        }
    }
}