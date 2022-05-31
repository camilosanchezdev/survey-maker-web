namespace SurveyMakerApi.Persistence.Models
{
    public class Question : BaseModel
    {
        public string Name { get; set; }
        public int SurveyId { get; set; }
        public bool Multiple { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<ResponseQuestion> ResponseQuestions { get; set; }
    }
}
