using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SurveyMakerApi.Core.Auth
{
    public class TokenFactory : ITokenFactory
    {
        private readonly Dictionary<string, TokenModel> refreshTokens;
        public TokenFactory()
        {
            refreshTokens = new Dictionary<string, TokenModel>();
        }
        public string GenerateAccessToken(string key, string issuer, int validityTime, Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                issuer, 
                claims: claims,
                expires: validityTime > 0 ? DateTime.UtcNow.AddMinutes(validityTime) : DateTime.UtcNow.AddYears(5),
                signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        public void SaveRefreshToken(long id, string newRefreshToken, DateTime expirationDate)
        {
            if (string.IsNullOrEmpty(newRefreshToken))
            {
                return;
            }

            refreshTokens.Add(newRefreshToken, new TokenModel { Id = id, RefreshToken = newRefreshToken, ExpirationDate = expirationDate });
        }
    }
}
