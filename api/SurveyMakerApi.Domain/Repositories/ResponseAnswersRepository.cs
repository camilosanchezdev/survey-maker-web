using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class ResponseAnswersRepository : Repository<SurveyMakerContext, ResponseAnswer>, IResponseAnswersRepository
    {
        public ResponseAnswersRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.ResponseAnswers;
        }
    }
}
