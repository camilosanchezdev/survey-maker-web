using SurveyMakerApi.Domain.DTOs;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IReportsService
    {
        Task<object> GetStatistics(int userId, int surveyId);
        Task<byte[]> GetReport(int userId, int surveyId);
        Task<KpiDTO> GetKpis(int userId);
    }
}
