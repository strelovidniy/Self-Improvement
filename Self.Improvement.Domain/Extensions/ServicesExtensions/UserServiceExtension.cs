using System.Linq;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Extensions.ServicesExtensions
{
    public static class UserServiceExtension
    {
        public static IQueryable<User> IncludeMessages(this IQueryable<User> users) => 
            users.Include(x => x.Messages);

        public static IQueryable<User> IncludeGoals(this IQueryable<User> users) => 
            users.Include(x => x.Goals);
    }
}
