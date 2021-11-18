using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.TelegramBot
{
    public class ChatBot
    {
        public TelegramBotClient Client { get; set; }
        public CancellationTokenSource Cts { get; set; }

        public ChatBot()
        {
            
        }

        public ChatBot(IOptions<ChatBotConfig> chatBotConfig)
        {
             
        }
        
        public void Init(string accessToken)
        {
            Client = new TelegramBotClient(accessToken);
            Cts = new CancellationTokenSource();
        }
    }
}