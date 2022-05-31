using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class ResponseAnswersService : Service<ResponseAnswer>, IResponseAnswersService
    {
        private readonly IMapper _mapper;
        private readonly IResponseAnswersRepository _repository;
        public ResponseAnswersService(IResponseAnswersRepository repository, IServiceProvider serviceProvider, IMapper mapper) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Create New Answer Response
        /// <summary>
        /// Create New Answer Response
        /// </summary>
        /// <param name="answerId"></param>
        /// <param name="responseQuestionId"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<ResponseAnswer> Create(int answerId, int responseQuestionId, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var answer = await base.Insert(new ResponseAnswer
                {
                    AnswerId = answerId,
                    ResponseQuestionId = responseQuestionId,
                }, transaction);

                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }
                return answer;
            }
            catch
            {
                if (inheritedTransaction == null)
                {
                    transaction.Rollback();
                }

                throw;
            }
        }
        #endregion

    }
}
