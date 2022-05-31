namespace SurveyMakerApi.Persistence.Models
{
    public class Response : BaseModel
    {
        public int SurveyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<ResponseQuestion> ResponseQuestions { get; set; }
    }
}
