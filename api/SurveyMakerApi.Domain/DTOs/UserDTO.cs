namespace SurveyMakerApi.Domain.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
