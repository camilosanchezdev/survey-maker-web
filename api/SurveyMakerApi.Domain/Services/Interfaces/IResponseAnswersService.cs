using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IResponseAnswersService
    {
        Task<ResponseAnswer> Create(int answerId, int responseQuestionId, IDbContextTransaction transaction = null);
    }
}
