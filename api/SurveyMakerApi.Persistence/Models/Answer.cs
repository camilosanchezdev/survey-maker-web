namespace SurveyMakerApi.Persistence.Models
{
    public class Answer : BaseModel
    {
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<ResponseAnswer> ResponseAnswers { get; set; }
    }
}
