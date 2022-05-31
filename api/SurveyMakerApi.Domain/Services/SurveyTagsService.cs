using AutoMapper;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    internal class SurveyTagsService : Service<SurveyTag>, ISurveyTagsService
    {
        private readonly IMapper _mapper;
        private readonly ISurveyTagsRepository _repository;
        public SurveyTagsService(ISurveyTagsRepository repository, IServiceProvider serviceProvider, IMapper mapper) 
            : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }
        #region Get All Survey Tags
        /// <summary>
        /// Get All Survey Tags
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<SurveyTag>> GetAll()
        {
            var records = await base.All();

            var result = new List<SurveyTag>();
            foreach (var item in records)
            {
                result.Add(item);
            }
            return result;
        }
        #endregion
    }
}
