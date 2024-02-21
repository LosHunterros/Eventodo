using Eventodo.Aplication.DTOs;
using Eventodo.Infrastructure.Repositorys;
using Eventodo.Core;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Eventodo.Aplication.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public UsersService(IUsersRepository repository, IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            User? user = await _repository.GetUserAsync(userName);

            return user;
        }

        public Task<IEnumerable<UserDTO>> GetUsersAsync(string? search, int memoryCacheDuration)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(UserRegisterDTO userRegisterDTO)
        {
            User user = _mapper.Map<User>(userRegisterDTO);

            IdentityResult result = await _repository.CreateUserAsync(user, userRegisterDTO.Password);

            return result;
        }

        public Task<bool> UpdateUserAsync(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> LoginUserAsync(User user, string password)
        {
            SignInResult result = await _repository.LoginUserAsync(user, password);

            return result;
        }

        public async Task<string> GetJWTAsync(User user, string JWTIssuer, string JWTAudience, string JWTSigningKey, int JWTExpires)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName!)
            };

            IList<string> roles = await GetRolesAsync(user);

            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSigningKey)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new(
                issuer: JWTIssuer,
                audience: JWTAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(JWTExpires),
                signingCredentials: signingCredentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            IList<string> roles = await _repository.GetRolesAsync(user);

            return roles;
        }
    }
}
