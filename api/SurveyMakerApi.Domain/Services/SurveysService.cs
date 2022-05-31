using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Core.Exceptions;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class SurveysService : Service<Survey>, ISurveysService
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _repository;
        private readonly Lazy<ISurveyTagsService> _surveyTagsService;
        private readonly Lazy<IQuestionsService> _questionsService;
        private readonly Lazy<IAnswersService> _answersService;
        public SurveysService(IMapper mapper, ISurveyRepository repository, IServiceProvider serviceProvider)
            : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
            _surveyTagsService = new Lazy<ISurveyTagsService>(() => serviceProvider.GetRequiredService<ISurveyTagsService>());
            _questionsService = new Lazy<IQuestionsService>(() => serviceProvider.GetRequiredService<IQuestionsService>());
            _answersService = new Lazy<IAnswersService>(() => serviceProvider.GetRequiredService<IAnswersService>());
        }
        #region Get All Surveys
        /// <summary>
        /// Get All Surveys
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public async Task<List<SurveyDto>> GetAll(int userId, int statusId = 0)
        {
            List<SurveyDto> list = new();
            var records = (await base.All())
                .Include(x => x.SurveyStatus)
                .Include(x => x.SurveyTags)
                .Where(s => s.User.Id.Equals(userId))
                 .OrderByDescending(x => x.CreatedAt);

            if (statusId != 0) records = records.Where(s => s.SurveyStatusId.Equals(statusId)).OrderByDescending(x => x.CreatedAt); ;
            
            foreach (var item in records)
            {
                var resultItem = _mapper.Map(item, new SurveyDto());
                list.Add(resultItem);
            }

            return list;
        }
        #endregion

        #region Create New Survey
        /// <summary>
        /// Create new survey
        /// </summary>
        /// <param name="input"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Survey> Create(SurveyInputDTO input, int userId, bool isDraft = false)
        {
            var transaction = _repository.BeginTransaction();
            var now = DateTime.Now;
            try
            {
                var record = _mapper.Map(input, new Survey());
                record.CreatedAt = now;
                record.CreatedBy = userId;
                record.SurveyStatusId = !isDraft ? (int)Persistence.Aggregates.SurveyStatus.Accessors.Active : (int)Persistence.Aggregates.SurveyStatus.Accessors.Draft;
                record.SurveyTags = await _surveyTagsService.Value.GetAll();
                record.Link = Guid.NewGuid();


                var result = await Insert(record, transaction);

                // Insert questions
                foreach (var questionToInsert in input.Questions)
                {
                    var question = await _questionsService.Value.Create(questionToInsert.Name, result.Id, questionToInsert.Multiple, transaction);

                    // Insert answers
                    foreach (var answer in questionToInsert.Answers)
                    {
                        await _answersService.Value.Create(answer.Name, question.Id, transaction);
                    }
                }

                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion

        #region Get Survey By Id
        /// <summary>
        /// Get Survey By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Survey> GetById(int userId, int surveyId)
        {
            var record = (await All()).Where(r => r.Id == surveyId && r.User.Id == userId && r.DeletedAt == null)
                .Include(x => x.SurveyStatus)
                .Include(x => x.SurveyTags)
                .Include(x => x.Questions.Where(r => r.DeletedAt == null))
                .ThenInclude(x => x.Answers.Where(r => r.DeletedAt == null))
                .FirstOrDefault();


            if (record == null)
            {
                throw new NotFoundException();
            }
            return record;
        }
        #endregion

        #region Get Survey By Link
        /// <summary>
        /// Get Survey By Link
        /// </summary>
        /// <param name="surveyLink"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<Survey> GetByLink(Guid surveyLink)
        {
            var record = (await All()).Where(r => r.Link == surveyLink && r.DeletedAt == null)
                .Include(x => x.SurveyStatus)
                .Include(x => x.SurveyTags)
                .Include(x => x.Questions.Where(r => r.DeletedAt == null))
                .ThenInclude(x => x.Answers.Where(r => r.DeletedAt == null))
                .FirstOrDefault();


            if (record == null)
            {
                throw new NotFoundException();
            }
            return record;
        }
        #endregion

        #region Get Report
        /// <summary>
        /// Get Report
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<object> GetReport(int userId, int surveyId)
        {
            var record = (await All()).Where(r => r.Id == surveyId && r.User.Id == userId)
                .Include(x => x.SurveyStatus)
                .Include(x => x.SurveyTags)
                .Include(x => x.Responses)
                .ThenInclude(x => x.ResponseQuestions)
                .ThenInclude(x => x.ResponseAnswers)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault();

            if (record == null)
            {
                throw new NotFoundException();
            }
            return record;
        }
        #endregion

        #region Mark Survey As Active
        /// <summary>
        /// Mark Survey As Active
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        Task<SurveyDto> ISurveysService.MarkAsActive(int surveyId)
        {
            return UpdateSurveyStatus(surveyId, (int)Persistence.Aggregates.SurveyStatus.Accessors.Active);
        }
        #endregion

        #region Mark Survey As Completed
        /// <summary>
        /// Mark Survey As Completed
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        Task<SurveyDto> ISurveysService.MarkAsCompleted(int surveyId)
        {
            return UpdateSurveyStatus(surveyId, (int)Persistence.Aggregates.SurveyStatus.Accessors.Completed);
        }
        #endregion

        #region Update Survey Status
        /// <summary>
        /// Update Survey Status
        /// </summary>
        /// <param name="surveyId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        private async Task<SurveyDto> UpdateSurveyStatus(int surveyId, int status)
        {
            var transaction = _repository.BeginTransaction();
            var now = DateTime.UtcNow;

            try
            {
                var task = (await Get(surveyId))
                    .Include(x => x.SurveyStatus)
                    .Include(x => x.SurveyTags)
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers)
                    .FirstOrDefault();


                if (task == null)
                {
                    throw new NotFoundException();
                }
                task.SurveyStatusId = status;

                await Update(task, transaction);

                transaction.Commit();

                var mapped = _mapper.Map(task, new SurveyDto());
                return mapped;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion

        #region Get Total Surveys
        /// <summary>
        /// Get Total Surveys
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<long> GetTotalSurveys(int userId)
        {
            var records = (await base.All())
                .Where(s => s.User.Id.Equals(userId)).Count();

            return records;
        }
        #endregion

        #region Get Total Surveys Active
        /// <summary>
        /// Get Total Surveys Active
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<long> GetTotalSurveysActive(int userId)
        {
            var records = (await base.All())
                .Where(s => s.User.Id.Equals(userId) && s.SurveyStatusId.Equals((int)Persistence.Aggregates.SurveyStatus.Accessors.Active)).Count();

            return records;
        }
        #endregion

        #region Get Total Surveys Completed
        /// <summary>
        /// Get Total Surveys Completed
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<long> GetTotalSurveysCompleted(int userId)
        {
            var records = (await base.All())
                .Where(s => s.User.Id.Equals(userId) && s.SurveyStatusId.Equals((int)Persistence.Aggregates.SurveyStatus.Accessors.Completed)).Count();

            return records;
        }
        #endregion

        #region Edit Survey
        /// <summary>
        /// Edit Survey
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<SurveyDto> Edit(int userId, int surveyId, SurveyInputDTO input)
        {
            return await EditSurvey(userId, surveyId, input, (int)Persistence.Aggregates.SurveyStatus.Accessors.Active);
        }
        #endregion

        #region Edit Survey As Draft
        /// <summary>
        /// Edit Survey As Draft
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<SurveyDto> EditDraft(int userId, int surveyId, SurveyInputDTO input)
        {
            return await EditSurvey(userId, surveyId, input, (int)Persistence.Aggregates.SurveyStatus.Accessors.Draft);
        }
        #endregion

        #region Edit Survey Logic
        /// <summary>
        /// Edit Survey Logic
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <param name="input"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private async Task<SurveyDto> EditSurvey(int userId, int surveyId, SurveyInputDTO input, int status)
        {
            var transaction = _repository.BeginTransaction();
            var now = DateTime.Now;
            try
            {
                var record = (await Get(surveyId))
                    .Include(x => x.SurveyStatus)
                    .Include(x => x.SurveyTags)
                    .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers)
                    .FirstOrDefault();


                if (record == null)
                {
                    throw new NotFoundException();
                }
               

                var recordUpdated = _mapper.Map(input, record);

                recordUpdated.SurveyStatusId = status;



                //
                foreach (var recordQuestion in record.Questions)
                {
                    var inputSingle = input.Questions.Where(r => r.Id == recordQuestion.Id).FirstOrDefault();

                    // Update
                    if(inputSingle != null)
                    {
                        await _questionsService.Value.Update(inputSingle, recordQuestion, transaction);
                        foreach (var answer in recordQuestion.Answers)
                        {
                            var inputAnswerSingle = inputSingle.Answers.Where(r => r.Id == answer.Id).FirstOrDefault();
                            // Update
                            if (inputAnswerSingle != null)
                            {
                                await _answersService.Value.Update(inputAnswerSingle, answer, transaction);
                            }
                            // Delete
                            else
                            {
                                await _answersService.Value.Delete(answer.Id, transaction);
                            }
                        }
                        // Insert
                        foreach (var item in inputSingle.Answers)
                        {
                            if (!recordQuestion.Answers.Where(r => r.Id == item.Id).Any())
                            {
                                await _answersService.Value.Create(item.Name, recordQuestion.Id, transaction);
                            }
                        }
                          
                    } 
                    // Delete
                    else
                    {
                        await _questionsService.Value.Delete(recordQuestion.Id, transaction);
                    }
                }
                foreach (var item in input.Questions)
                {
                   if(!record.Questions.Where(r => r.Id == item.Id).Any())
                    {
                        var question = await _questionsService.Value.Create(item.Name, record.Id, item.Multiple, transaction);
                        foreach (var itemAnswer in item.Answers)
                        {
                            await _answersService.Value.Create(itemAnswer.Name, question.Id, transaction);
                        }
                    }
                }
                await Update(recordUpdated, transaction);

                transaction.Commit();
                var mapped = _mapper.Map(recordUpdated, new SurveyDto());
                return mapped;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        #endregion
    }
}
