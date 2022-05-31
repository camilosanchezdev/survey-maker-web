using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class SurveyTagsRepository : Repository<SurveyMakerContext, SurveyTag>, ISurveyTagsRepository
    {
        public SurveyTagsRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.SurveyTags;
        }
    }
}
