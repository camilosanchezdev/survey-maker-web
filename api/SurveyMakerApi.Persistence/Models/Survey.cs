namespace SurveyMakerApi.Persistence.Models
{
    public class Survey : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid Link { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndsAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public int SurveyStatusId { get; set; }
        public int CreatedBy { get; set; }
        public virtual SurveyStatus SurveyStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SurveyTag> SurveyTags { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
