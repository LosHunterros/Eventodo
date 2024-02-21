using Eventodo.Core;
using Microsoft.AspNetCore.Identity;

namespace Eventodo.Infrastructure.Repositorys
{
    public interface IUsersRepository
    {
        Task<User?> GetUserAsync(string userName);
        Task<IEnumerable<User>> GetUsersAsync(string? search);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<SignInResult> LoginUserAsync(User user, string password);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
