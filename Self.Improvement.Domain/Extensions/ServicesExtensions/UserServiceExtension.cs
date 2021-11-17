using System.Linq;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Extensions.ServicesExtensions
{
    public static class UserServiceExtension
    {
        public static IQueryable<User> IncludeChatWithMessages(this IQueryable<User> users) => 
            users
                .Include(user => user.Chat)
                .ThenInclude(chat => chat.Messages);

        public static IQueryable<User> IncludeGoals(this IQueryable<User> users) => 
            users
                .Include(user => user.Goals);
    }
}
