using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetUnreadChatsAsync() => 
            Ok(await _chatService.GetUnreadChatsAsync());

        [HttpGet("read")]
        public async Task<IActionResult> GetReadChatsAsync() => 
            Ok(await _chatService.GetReadChatsAsync());

        [HttpGet("{chatId:guid}")]
        public async Task<IActionResult> SendMessageAsync(Guid chatId) => 
            Ok(await _chatService.GetChatByIdAsync(chatId));
    }
}