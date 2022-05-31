using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface ISurveysService
    {
        Task<List<SurveyDto>> GetAll(int userId, int statusId = 0);
        Task<Survey> Create(SurveyInputDTO input, int userId, bool isDraft = false);

        Task<Survey> GetById(int userId, int surveyId);
        Task<Survey> GetByLink(Guid surveyLink);
        Task<SurveyDto> MarkAsActive(int surveyId);
        Task<SurveyDto> MarkAsCompleted(int surveyId);
        Task<object> GetReport(int userId, int surveyId);

        Task<long> GetTotalSurveys(int userId);
        Task<long> GetTotalSurveysActive(int userId);
        Task<long> GetTotalSurveysCompleted(int userId);

        Task<SurveyDto> Edit(int userId, int surveyId, SurveyInputDTO input);
        Task<SurveyDto> EditDraft(int userId, int surveyId, SurveyInputDTO input);
    }
}
