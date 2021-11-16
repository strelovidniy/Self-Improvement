using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Self.Improvement.Domain.Configs;
using Self.Improvement.Domain.Services.Implementations;
using Self.Improvement.Domain.TelegramBot;

namespace Self.Improvement.Web.Controllers
{
    [ApiController]
    public class BotController : Controller
    {
        private readonly IOptions<ChatBotConfig> _accesToken;
        private readonly TelegramHandlersService _tgHandler;

        public BotController(IOptions<ChatBotConfig> accesToken, TelegramHandlersService tgHandler)
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