using Newtonsoft.Json;

namespace SurveyMakerApi.Domain.DTOs
{
    [JsonObject]
    public class SurveyInputDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndsAt { get; set; }
        public List<long> SurveyTags { get; set; }
        public List<QuestionInputDto> Questions { get; set; }
    }
    public class QuestionInputDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool Multiple { get; set; }
        public List<AnswerInputDto> Answers { get; set; }
    }
    public class AnswerInputDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
