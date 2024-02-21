using Eventodo.Core;
using Microsoft.AspNetCore.Identity;

namespace Eventodo.Infrastructure.Repositorys
{
    public class UsersRepository : IUsersRepository
    {
        private readonly EventodoDbContext _eventodoDbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersRepository(EventodoDbContext eventodoDbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _eventodoDbContext = eventodoDbContext ?? throw new ArgumentNullException(nameof(eventodoDbContext));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            User? user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public Task<IEnumerable<User>> GetUsersAsync(string? search)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return result;
            }
            string[] userRole = { "User" };

            result = await _userManager.AddToRolesAsync(user, userRole);

            return result;
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> LoginUserAsync(User user, string password)
        {
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            return result;
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);

            return roles;
        }

    }
}
