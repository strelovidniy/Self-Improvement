using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;

namespace Self.Improvement.Domain.Bot
{
    public class ChatBot
    {
        #region Properties

        public TelegramBotClient TgBotClient { get; set; }
        public CancellationTokenSource Cts { get; set; }

        #endregion

        #region Public Methods

        public void Init(string accessToken)
        {
            TgBotClient = new TelegramBotClient(accessToken);
            Cts = new CancellationTokenSource();
        }

        public void Start(Func<ITelegramBotClient, Update, CancellationToken, Task> updateHandler,
            Func<ITelegramBotClient, Exception, CancellationToken, Task> errorHandler)
        {
            TgBotClient.StartReceiving(new DefaultUpdateHandler(updateHandler, errorHandler), Cts.Token);
        }

        #endregion
    }
}