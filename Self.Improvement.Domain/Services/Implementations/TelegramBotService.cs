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
            KeyboardButton specialistButton = new KeyboardButton("Specialist");
            KeyboardButton goalsButton = new KeyboardButton("Goals");
            
            List<KeyboardButton> buttonsList = new List<KeyboardButton>();
            
            buttonsList.Add(specialistButton);
            buttonsList.Add(goalsButton);
            
            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(buttonsList);
            keyboard.ResizeKeyboard = true;

            await _tgBot.Client.SendTextMessageAsync(update.Message.Chat.Id, "Welcome back, choose what you gonna do!");
        }
    }
}