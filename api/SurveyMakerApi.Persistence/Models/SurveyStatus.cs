namespace SurveyMakerApi.Persistence.Models
{
    public partial class SurveyStatus : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
