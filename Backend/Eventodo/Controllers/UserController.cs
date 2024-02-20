using Eventodo.Configurations.Options;
using Eventodo.Aplication.Services;
using Eventodo.Aplication.DTOs;
using Eventodo.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Eventodo.Controllers
{
    [ApiController]
    [Route("api/users")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly CacheOptions _cacheOptions;
        private readonly JWTOptions _JWTOptions;

        public UserController(IUsersService service, IOptions<CacheOptions> cacheOptions, IOptions<JWTOptions> JWTOptions)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _cacheOptions = cacheOptions.Value ?? throw new ArgumentNullException(nameof(cacheOptions));
            _JWTOptions = JWTOptions.Value ?? throw new ArgumentNullException(nameof(JWTOptions));
        }

        [HttpPost()]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            IdentityResult result = await _service.CreateUserAsync(userRegisterDTO);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Accepted($"User '{userRegisterDTO.UserName}' has been created");
        }

        [HttpPost()]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            User? user = await _service.GetUserAsync(userLoginDTO.UserName);

            if (user == null)
            {
                return Unauthorized(userLoginDTO);
            }

            SignInResult result = await _service.LoginUserAsync(user, userLoginDTO.Password);

            if (!result.Succeeded)
            {
                return Unauthorized(result);
            }

            string token = await _service.GetJWTAsync(user, _JWTOptions.Issuer, _JWTOptions.Audience, _JWTOptions.SigningKey, _JWTOptions.Expires);

            return Accepted(new { Token = token });
        }
    }
}
