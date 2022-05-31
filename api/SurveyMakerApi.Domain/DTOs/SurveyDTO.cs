namespace SurveyMakerApi.Domain.DTOs
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Link { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public int UserId { get; set; }
        public int SurveyStatusId { get; set; }
        public List<string> SurveyTags { get; set; }
        public List<QuestionDTO> Questions { get; set; }
        public bool HasResponses { get; set; }
    }
}
