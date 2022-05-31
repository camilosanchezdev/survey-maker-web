using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories.Interfaces
{
    public class SurveyStatusesRepository : Repository<SurveyMakerContext, SurveyStatus>, ISurveyStatusesRepository
    {
        public SurveyStatusesRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.SurveyStatuses;
        }

    }
}
