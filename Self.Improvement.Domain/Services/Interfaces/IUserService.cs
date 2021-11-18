using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(Guid userId);
        public Task<Guid> GetUserIdByTelegramIdAsync(int userId);
        public Task<IEnumerable<User>> GetAllAsync();
        public Task<User> UpdateUserAsync(User user);
        public Task<User> AddUserAsync(User user);
        public Task<bool> RemoveUserByIdAsync(Guid userId);
    }
}
