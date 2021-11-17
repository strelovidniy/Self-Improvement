using System.Linq;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Extensions.ServicesExtensions
{
    public static class ChatServiceExtension
    {
        public static IQueryable<Chat> IncludeMessages(this IQueryable<Chat> chats) => 
            chats
                .Include(chat => chat.Messages);
    }
}
