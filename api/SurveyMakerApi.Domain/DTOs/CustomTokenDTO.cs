namespace SurveyMakerApi.Domain.DTOs
{
    public class CustomTokenDTO
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
