using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Self.Improvement.Data.Entities;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IChatService _chatService;

        public SignalRHub(IChatService chatService) => 
            _chatService = chatService;

        public async Task EnterToGroup(string groupName) => 
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        public async Task LeaveTheGroup(string groupName) => 
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        public async Task SendMessageToGroup(Message message) => 
            await Clients
                .Group(message.ChatId.ToString())
                .SendAsync("RecieveMessage", await _chatService.ReceiveMessageAsync(message));
    }
}
