using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface ISurveyTagsService
    {
        Task<ICollection<SurveyTag>> GetAll();
    }
}
