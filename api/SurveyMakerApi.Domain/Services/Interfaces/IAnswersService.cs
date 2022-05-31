using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IAnswersService
    {
        Task<Answer> Create(string input, int questionId, IDbContextTransaction transaction = null);
        Task<Answer> Update(AnswerInputDto input, Answer currentRecord, IDbContextTransaction transaction = null);
        Task<Answer> Delete(int answerId, IDbContextTransaction inheritedTransaction = null);
    }
}
