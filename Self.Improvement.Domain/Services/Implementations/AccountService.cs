using System;
using System.Threading;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;
using Self.Improvement.Domain.Models;
using Self.Improvement.Domain.Services.Interfaces;

namespace Self.Improvement.Domain.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task CreateNewUserIfNotExistAsync(string email, string userName, CancellationToken ct)
        {
            var existUser = await _userService.GetUserByEmailIfExistAsync(email, ct);

            if (existUser == null)
            {
                await _userService.AddUserAsync(new User
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    Name = userName
                });
            }
        }

        public async Task<UserAuthorizationData> GetUserAuthorizationDataAsync(string email, CancellationToken ct)
        {
            var user = await _userService.GetUserByEmailIfExistAsync(email, ct);

            if (user == null)
            {
                return null;
            }

            return new UserAuthorizationData { UserId = user.Id, UserRole = user.Role };
        }
    }
}