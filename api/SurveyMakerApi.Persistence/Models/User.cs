namespace SurveyMakerApi.Persistence.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt {  get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
