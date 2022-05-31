namespace SurveyMakerApi.Domain.DTOs
{
    public class KpiDTO
    {
        public long TotalSurveys { get; set; }
        public long TotalSurveysActive { get; set; }
        public long TotalSurveysCompleted { get; set; }
        public long TotalResponses { get; set; }
    }
}
