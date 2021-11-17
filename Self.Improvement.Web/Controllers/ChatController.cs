using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Self.Improvement.Data.Entities;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Web.Controllers
{
    [Route("api/v1/chats")]
    public class ChatController : BaseApiController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService) =>
            _chatService = chatService;

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadChatsAsync()
        {
            var result = await _chatService.GetUnreadChatsAsync();

            return Ok(result);
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetReadChatsAsync()
        {
            var result = await _chatService.GetReadChatsAsync();

            return Ok(result);
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessageAsync([FromBody] Message message)
        {
            var result = await _chatService.SendMessageAsync(message);

            return Ok(result);
        }
    }
}