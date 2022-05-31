using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Core.Exceptions;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class AnswersService : Service<Answer>, IAnswersService
    {
        private readonly IMapper _mapper;
        private readonly IAnswersRepository _repository;
        public AnswersService(IAnswersRepository repository, IServiceProvider serviceProvider, IMapper mapper) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Create new Answer
        /// <summary>
        /// Create new Answer
        /// </summary>
        /// <param name="input"></param>
        /// <param name="questionId"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<Answer> Create(string input, int questionId, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var answer = await base.Insert(new Answer
                {
                    Name = input,
                    QuestionId = questionId,
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

        #region
        /// <summary>
        /// Update Answer
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentRecord"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<Answer> Update(AnswerInputDto input, Answer currentRecord, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var record = _mapper.Map(input, currentRecord);
                var answer = await base.Update(record, transaction);

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

        #region Delete Answer
        /// <summary>
        /// Delete Answer
        /// </summary>
        /// <param name="answerId"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>

        public async Task<Answer> Delete(int answerId, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();
            var now = DateTime.Now;

            try
            {
                var answer = (await Get(answerId))
                    .FirstOrDefault();


                if (answer == null)
                {
                    throw new NotFoundException();
                }
                answer.DeletedAt = DateTime.Now;

                answer = await Update(answer, transaction);

                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }
                return answer;

            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion
    }
}
