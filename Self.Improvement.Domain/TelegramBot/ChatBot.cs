using System.Threading;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Telegram.Bot;

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