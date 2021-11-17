using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Domain.Services.Interfaces;
using Telegram.Bot.Types;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TelegramListenerController : BaseApiController
    {
        private readonly ITelegramService _tgService;

        public TelegramListenerController(ITelegramService tgService)
        {
            _tgService = tgService;
        }
        [HttpPost]
        public IActionResult Update([FromBody] Update update, CancellationToken cancellationToken)
        {
            _tgService.StartTelegramBot();
            return Ok("ok");
        }
    }
}