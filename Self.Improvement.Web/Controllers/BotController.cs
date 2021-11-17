using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Interfaces;
using Self.Improvement.Domain.TelegramBot;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : Controller
    {
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly ITelegramHandlersService _tgHandler;

        public BotController(IOptions<ChatBotConfig> accesToken, ITelegramHandlersService tgHandler)
        {
            _accesToken = accesToken;
            _tgHandler = tgHandler;
        }
        
        // GET
        [HttpGet]
        public JsonResult Index()
        {
            ChatBot chatBot = new ChatBot();
            chatBot.Init(_accesToken.Value.AccessToken);
            chatBot.Start(_tgHandler.HandleUpdateAsync, _tgHandler.HandleErrorAsync);
            return Json("Bot");
        }
    }
}