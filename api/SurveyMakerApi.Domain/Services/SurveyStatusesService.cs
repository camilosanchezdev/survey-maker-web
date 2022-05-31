using AutoMapper;
using SurveyMakerApi.Core.Domain.Repositories;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class SurveyStatusesService : Service<SurveyStatus>, ISurveyStatusesService
    {
        private readonly IMapper _mapper;
        private readonly ISurveyStatusesRepository _repository;
        public SurveyStatusesService(ISurveyStatusesRepository repository, IServiceProvider serviceProvider, IMapper mapper) 
            : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Get All Survey Statuses
        /// <summary>
        /// Get All Survey Statuses
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetAll()
        {
            var records = await _repository.All();
            return records; ;
        }
        #endregion
    }
}
