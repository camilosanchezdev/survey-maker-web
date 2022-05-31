using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class ResponseQuestionsRepository : Repository<SurveyMakerContext, ResponseQuestion>, IResponseQuestionsRepository
    {
        public ResponseQuestionsRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.ResponseQuestions;
        }
    }
}
