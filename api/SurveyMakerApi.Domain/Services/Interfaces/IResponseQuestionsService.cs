using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IResponseQuestionsService
    {
        Task<ResponseQuestion> Create(ResponseQuestionInputDTO input, int responseId, IDbContextTransaction transaction = null);
    }
}
