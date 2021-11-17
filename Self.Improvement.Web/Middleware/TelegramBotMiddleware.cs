using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Self.Improvement.Domain.Services.Implementations;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Middleware
{
    public class TelegramBotMiddleware
    {
        #region Fields

        private readonly RequestDelegate _next;
        private readonly ITelegramService _tgService;

        #endregion

        #region Ctor

        public TelegramBotMiddleware(RequestDelegate next, ITelegramService tgService)
        {
            _next = next;
            _tgService = tgService;
        }

        #endregion

        #region Public Methods

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Response.HasStarted is not false)
            {
                _tgService.StartTelegramBot();
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        #endregion
    }
}