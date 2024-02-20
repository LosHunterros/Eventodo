using Eventodo.Aplication.DTOs;
using Eventodo.Core;
using Microsoft.AspNetCore.Identity;

namespace Eventodo.Aplication.Services
{
    public interface IUsersService
    {
        Task<User?> GetUserAsync(string userName);
        Task<IEnumerable<UserDTO>> GetUsersAsync(string? search, int memoryCacheDuration);
        Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO);
        Task<bool> UpdateUserAsync(UserDTO userDTO);
        Task<bool> DeleteUserAsync(int id);
        Task<SignInResult> LoginUserAsync(User user, string password);
        Task<string> GetJWTAsync(User user, string JWTIssuer, string JWTAudience, string JWTSigningKey, int JWTExpires);
        Task<IList<string>> GetRolesAsync(User user);
    }
}
