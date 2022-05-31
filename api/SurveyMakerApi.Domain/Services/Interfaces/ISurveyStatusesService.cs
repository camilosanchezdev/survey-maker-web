namespace SurveyMakerApi.Domain.Services.Interfaces
{
    public partial interface ISurveyStatusesService
    {
        Task<object> GetAll();
    }
}
