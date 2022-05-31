using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Domain.DTOs;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IResponsesService
    {
        Task<object> Create(ResponseInputDTO input, IDbContextTransaction transaction = null);
        Task<ResponseDTO> GetById(int userId, int surveyId);
        Task<bool> HasAnswers(int surveyId);
        Task<long> TotalResponses(int userId);
    }
}
