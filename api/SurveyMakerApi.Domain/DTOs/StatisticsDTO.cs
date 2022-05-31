namespace SurveyMakerApi.Domain.DTOs
{
    public class StatisticsDTO
    {
        public int ResponsesQuantity { get; set; }
        public List<QuestionAnswerDTO> QuestionAnswer { get; set; }
    }
    public class QuestionAnswerDTO
    {
        public int QuestionId { get; set; }
        public List<AnswerQuantityDTO> AnswerQuantity { get; set; }
    }
    public class AnswerQuantityDTO
    {
        public int AnswerId { get; set; }
        public int Quantity { get; set; }
    }
}
