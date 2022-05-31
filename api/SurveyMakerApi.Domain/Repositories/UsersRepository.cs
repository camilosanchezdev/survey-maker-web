using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Persistence.Context;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Repositories
{
    public class UsersRepository : Repository<SurveyMakerContext, User>, IUsersRepository
    {
        public UsersRepository(SurveyMakerContext context) : base(context)
        {
            DataSet = context.User;
        }

    }
}
