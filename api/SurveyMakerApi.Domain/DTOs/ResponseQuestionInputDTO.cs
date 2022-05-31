namespace SurveyMakerApi.Domain.DTOs
{
    public class ResponseQuestionInputDTO
    {
        public int QuestionId { get; set; }
        public List<int> AnswerIds { get; set; }
    }
}
