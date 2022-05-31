using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class ResponsesRepository : Repository<SurveyMakerContext, Response>, IResponsesRepository
    {
        public ResponsesRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.Responses;
        }
    }
}
