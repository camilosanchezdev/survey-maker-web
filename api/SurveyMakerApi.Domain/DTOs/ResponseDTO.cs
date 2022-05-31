namespace SurveyMakerApi.Domain.DTOs
{
    public class ResponseDTO
    {
        public int ResponseQuantity { get; set; }
        public string SurveyTitle { get; set; }
        public int SurveyId { get; set; }
        public List<ResponseQuestionAnswer> QuestionAnswer { get; set; }
    }
    public class ResponseQuestionAnswer
    {
        public int QuestionId { get; set; }
        public string? QuestionName { get; set; }
        public List<AnswerQuantity> AnswerQuantity{ get; set; }
    }
    public class AnswerQuantity
    {
        public int AnswerId { get; set; }
        public string? AnswerName { get; set; }
        public int Quantity { get; set; }
    }
}
