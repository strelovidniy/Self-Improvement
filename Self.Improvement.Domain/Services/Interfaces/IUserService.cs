using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<Guid> GetUserIdByTelegramIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateUserAsync(User user);
        Task<User> AddUserAsync(User user);
        Task<bool> RemoveUserByIdAsync(Guid userId);
        Task<User> GetUserByEmailIfExistAsync(string email, CancellationToken ct);
    }
}