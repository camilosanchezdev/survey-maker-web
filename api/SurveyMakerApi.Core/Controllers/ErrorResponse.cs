using Newtonsoft.Json;

namespace SurveyMakerApi.Core.Controllers
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
