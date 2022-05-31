using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class AnswersRepository : Repository<SurveyMakerContext, Answer>, IAnswersRepository
    {
        public AnswersRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.Answers;
        }
    }
}
