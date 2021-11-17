﻿using System;
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
    }
}
