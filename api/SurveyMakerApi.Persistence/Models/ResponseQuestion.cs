using System.Runtime.Serialization;

namespace SurveyMakerApi.Persistence.Models
{
    public class ResponseQuestion : BaseModel
    {
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
        public virtual ICollection<ResponseAnswer> ResponseAnswers { get; set; }
        public virtual Response Response { get; set; }
    }
}
