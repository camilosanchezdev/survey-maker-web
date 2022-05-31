using System.Security.Claims;

namespace SurveyMakerApi.Core.Auth
{
    public interface ITokenFactory
    {
        string GenerateAccessToken(string key, string issuer, int validityTime, Claim[] claims);
        string GenerateRefreshToken();
        void SaveRefreshToken(long id, string newRefreshToken, DateTime expirationDate);


    }
}