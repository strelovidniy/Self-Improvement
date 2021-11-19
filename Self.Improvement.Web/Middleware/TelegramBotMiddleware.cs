using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Self.Improvement.Web.Middleware
{
    public class TelegramBotMiddleware
    {
        private readonly RequestDelegate _next;

        public TelegramBotMiddleware(RequestDelegate next) => 
            _next = next;

        public async Task InvokeAsync(HttpContext context) => 
            await _next.Invoke(context);
    }
}