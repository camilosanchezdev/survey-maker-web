using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class ResponseQuestionsService : Service<ResponseQuestion>, IResponseQuestionsService
    {
        private readonly IMapper _mapper;
        private readonly IResponseQuestionsRepository _repository;
        private readonly Lazy<IResponseAnswersService> _responseAnswersService;
        public ResponseQuestionsService(IResponseQuestionsRepository repository, IServiceProvider serviceProvider, IMapper mapper) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
            _responseAnswersService = new Lazy<IResponseAnswersService>(() => serviceProvider.GetRequiredService<IResponseAnswersService>());
        }

        #region Create New Response Question
        /// <summary>
        /// Create New Response Question
        /// </summary>
        /// <param name="input"></param>
        /// <param name="responseId"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<ResponseQuestion> Create(ResponseQuestionInputDTO input, int responseId, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var question = await base.Insert(new ResponseQuestion
                {
                    QuestionId = input.QuestionId,
                    ResponseId = responseId
                }, transaction);

                foreach (var answerId in input.AnswerIds)
                {
                    await _responseAnswersService.Value.Create(answerId, question.Id, transaction);
                }
                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }
                return question;
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
