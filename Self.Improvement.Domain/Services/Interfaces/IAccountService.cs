using System.Threading;
using System.Threading.Tasks;
using Self.Improvement.Data.Entities;
using Self.Improvement.Domain.Models;

namespace Self.Improvement.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateNewUserIfNotExistAsync(string email, string userName, CancellationToken ct);
        Task<UserAuthorizationData> GetUserAuthorizationDataAsync(string email, CancellationToken ct);
        Task<User> GetUserByEmailAsync(string email, CancellationToken ct);
    }
}