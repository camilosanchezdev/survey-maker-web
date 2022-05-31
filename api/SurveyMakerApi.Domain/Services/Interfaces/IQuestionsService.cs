using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface IQuestionsService
    {
        Task<Question> Create(string input, int surveyId, bool multiple, IDbContextTransaction transaction = null);
        Task<Question> Update(QuestionInputDto input, Question currentRecord, IDbContextTransaction transaction = null);
        Task<Question> Delete(int questionId, IDbContextTransaction inheritedTransaction = null);
    }
}
