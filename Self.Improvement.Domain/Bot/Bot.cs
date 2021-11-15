using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;


namespace Bot
{
    class Bot
    {
        #region Properties
        public TelegramBotClient tgBotClient { get; set; }
        public CancellationTokenSource cts { get; set; }
        
        #endregion

        #region Public Methods

        public void Init(string accessToken)
        {
            tgBotClient = new TelegramBotClient(accessToken);
            cts = new CancellationTokenSource();
        }

        public void Start(Func<ITelegramBotClient, Update, CancellationToken, Task> updateHandler,
            Func<ITelegramBotClient, Exception, CancellationToken, Task> errorHandler)
        {
            tgBotClient.StartReceiving(new DefaultUpdateHandler(updateHandler, errorHandler), cts.Token);
        }

        #endregion
        
    }
}
