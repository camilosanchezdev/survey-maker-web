using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SurveyMakerApi.Core.Auth;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Services.Interfaces;
using System.Security.Claims;

namespace SurveyMakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;
        private readonly ITokenFactory _tokenFactory;
        private readonly JWTConfig _config;
        private IConfiguration configuration;
        public AuthController(IMapper mapper, IUsersService usersService, ITokenFactory tokenFactory, IOptions<JWTConfig> config)
        {
            _usersService = usersService;
            _mapper = mapper;
            _tokenFactory = tokenFactory;
            _config = config.Value;
        }
        #region Login Authentication
        /// <summary>
        /// Login Authentication
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO input)
        {
            var user = await _usersService.Login(input.Email, input.Password);
            return AuthOk(user);
        }
        #endregion

        #region Register New User
        /// <summary>
        /// Register New User
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO input)
        {
            var user = await _usersService.Register(input);
            return Ok(user);
        }
        #endregion

        #region Generate Custom Token
        /// <summary>
        /// Generate Custom Token Internal
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        protected ActionResult AuthOk(UserDTO auth)
        {
            var token = _tokenFactory.GenerateAccessToken(_config.JWT.Key, _config.JWT.Issuer, _config.JWT.ValidityTime, GetClaims(auth));
            string refreshToken = _tokenFactory.GenerateRefreshToken();
            _tokenFactory.SaveRefreshToken(auth.UserId, refreshToken, DateTime.UtcNow.AddMinutes(1440)); // one hour

            return Ok(new CustomTokenDTO
            {
                Token = token,
                Email = auth.Email,
                Name = auth.Name,
                ExpirationDate = DateTime.UtcNow.AddMinutes(1440),
                RefreshToken = refreshToken,
                Id = auth.UserId,
                CreatedAt = auth.CreatedAt,
            });
        }
        #endregion

        #region Get Claims
        /// <summary>
        /// Get Claims
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected Claim[] GetClaims(UserDTO user)
        {
            var claims = new List<Claim> {
                new Claim("user_id", user.UserId.ToString()),
                new Claim("user_name", user.Name),
            };

            return claims.ToArray();
        }
        #endregion
    }
}