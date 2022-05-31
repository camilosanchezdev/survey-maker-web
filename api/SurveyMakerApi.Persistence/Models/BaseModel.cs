namespace SurveyMakerApi.Persistence.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
