using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Persistence.Models;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;

namespace SurveyMakerApi.Domain.Repositories
{
    public class SurveyRepository : Repository<SurveyMakerContext, Survey>, ISurveyRepository
    {
        public SurveyRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.Survey;
        }
        
    }
}
