using System;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserByIdAsync(Guid userId);
    }
}
