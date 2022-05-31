namespace SurveyMakerApi.Domain.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Multiple { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
