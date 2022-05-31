using System.Runtime.Serialization;

namespace SurveyMakerApi.Persistence.Models
{
    public class ResponseAnswer : BaseModel
    {
        public int AnswerId { get; set; }
        public int ResponseQuestionId { get; set; }
        public virtual ResponseQuestion ResponseQuestion { get; set; }
    }
}
