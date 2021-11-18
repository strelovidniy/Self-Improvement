using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Self.Improvement.Data.Entities;
using Self.Improvement.Data.Infrastructure;
using Self.Improvement.Domain.Extensions.ServicesExtensions;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository) =>
            _userRepository = userRepository;

        public Task<User> GetUserByIdAsync(Guid userId)
            => _userRepository
                .Query()
                .IncludeChatWithMessages()
                .IncludeGoals()
                .FirstOrDefaultAsync(user => user.Id == userId);

        public async Task<Guid> GetUserIdByTelegramIdAsync(int userTelegramId) =>
            (
                await _userRepository
                .Query()
                .FirstOrDefaultAsync(user => user.TelegramId == userTelegramId)
            ).Id;

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _userRepository.Query().ToListAsync();

        public async Task<User> UpdateUserAsync(User user)
        {
            var updatingUser = await _userRepository.GetByIdAsync(user.Id);

            if (updatingUser == null) return null;

            updatingUser.Name = user.Name;
            updatingUser.Chat = user.Chat;
            updatingUser.Goals = user.Goals;
            updatingUser.Role = user.Role;
            updatingUser.TelegramId = user.TelegramId;
            updatingUser.Email = user.Email;

            await _userRepository.SaveChangesAsync();

            return updatingUser;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var addedUser = await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return addedUser;
        }

        public async Task<bool> RemoveUserByIdAsync(Guid userId)
        {
            var deletingUser = await _userRepository.GetByIdAsync(userId);

            if (deletingUser is null) return false;

            var result = await _userRepository.DeleteAsync(deletingUser);

            await _userRepository.SaveChangesAsync();

            return result;
        }
    }
}
