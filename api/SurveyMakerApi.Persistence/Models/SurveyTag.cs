namespace SurveyMakerApi.Persistence.Models
{
    public class SurveyTag : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
