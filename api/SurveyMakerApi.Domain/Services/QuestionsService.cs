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
    public class QuestionsService : Service<Question>, IQuestionsService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionsRepository _repository;
        public QuestionsService(IQuestionsRepository repository, IServiceProvider serviceProvider, IMapper mapper) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
        }

        #region Create New Question
        /// <summary>
        /// Create New Question
        /// </summary>
        /// <param name="input"></param>
        /// <param name="surveyId"></param>
        /// <param name="multiple"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<Question> Create(string input, int surveyId, bool multiple, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var question = await base.Insert(new Question
                {
                    Name = input,
                    SurveyId = surveyId,
                    Multiple = multiple
                }, transaction);

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

        #region Update Question
        /// <summary>
        /// Update Question
        /// </summary>
        /// <param name="input"></param>
        /// <param name="currentRecord"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<Question> Update(QuestionInputDto input, Question currentRecord, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var record = _mapper.Map(input, currentRecord);
                var question = await base.Update(record, transaction);

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

        #region Delete Question
        /// <summary>
        /// Delete Question
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Question> Delete(int questionId, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();
            var now = DateTime.Now;

            try
            {
                var question = (await Get(questionId))
                    .FirstOrDefault();


                if (question == null)
                {
                    throw new NotFoundException();
                }
                question.DeletedAt = DateTime.Now;

                question = await Update(question, transaction);

                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }
                return question;

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
