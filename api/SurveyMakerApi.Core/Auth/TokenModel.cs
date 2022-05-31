namespace SurveyMakerApi.Core.Auth
{
    public class TokenModel
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Display { get; set; }
        public bool IsValid => (ExpirationDate > DateTime.UtcNow);
    }
}
