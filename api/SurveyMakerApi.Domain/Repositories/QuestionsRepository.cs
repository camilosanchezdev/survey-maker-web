using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class QuestionsRepository : Repository<SurveyMakerContext, Question>, IQuestionsRepository
    {
        public QuestionsRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.Questions;
        }
    }
}
