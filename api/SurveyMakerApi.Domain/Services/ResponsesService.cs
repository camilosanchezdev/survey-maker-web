using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using SurveyMakerApi.Core.Domain.Services;
using SurveyMakerApi.Core.Exceptions;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Repositories.Interfaces;
using SurveyMakerApi.Domain.Services.Interfaces;
using SurveyMakerApi.Persistence.Models;

namespace SurveyMakerApi.Domain.Services
{
    public class ResponsesService : Service<Response>, IResponsesService
    {
        private readonly IMapper _mapper;
        private readonly IResponsesRepository _repository;
        private readonly Lazy<ISurveysService> _surveyService;
        private readonly Lazy<IResponseQuestionsService> _responseQuestionsService;
        public ResponsesService(IResponsesRepository repository, IServiceProvider serviceProvider, IMapper mapper) : base(repository, serviceProvider)
        {
            _mapper = mapper;
            _repository = repository;
            _surveyService = new Lazy<ISurveysService>(() => serviceProvider.GetRequiredService<ISurveysService>());
            _responseQuestionsService = new Lazy<IResponseQuestionsService>(() => serviceProvider.GetRequiredService<IResponseQuestionsService>());
        }

        #region Create New Response
        /// <summary>
        /// Create New Response
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inheritedTransaction"></param>
        /// <returns></returns>
        public async Task<object> Create(ResponseInputDTO input, IDbContextTransaction inheritedTransaction = null)
        {
            var transaction = inheritedTransaction ?? _repository.BeginTransaction();

            try
            {
                var survey = _surveyService.Value.GetByLink(input.Link).Result;

                var response = await base.Insert(
                    new Response
                    {
                        SurveyId = survey.Id,

                    }, transaction);
                foreach (var item in input.Answers)
                {
                    await _responseQuestionsService.Value.Create(item, response.Id, transaction);
                }
                if (inheritedTransaction == null)
                {
                    transaction.Commit();
                }
                return response;
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

        #region Get Responses By Survey Id
        /// <summary>
        /// Get Responses By Survey Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<ResponseDTO> GetById(int userId, int surveyId)
        {
            var record2 = await _surveyService.Value.GetById(userId, surveyId);
            List<Question> questions = record2.Questions.ToList();
            var record = (await All())
                   .Where(r => r.SurveyId == surveyId)
                    .Include(x => x.ResponseQuestions)
                   .ThenInclude(x => x.ResponseAnswers);

            if (record == null)
            {
                throw new NotFoundException();
            }
            int cuantity = record.Count();
            var questionAnswer = record.SelectMany(x => x.ResponseQuestions, (parent, children) => new { Key = children.QuestionId, Parent = parent }
            ).ToList().GroupBy(x => x.Key, x => x.Parent).Select(question => {
                var currentQuestion = questions.FirstOrDefault(x => x.Id == question.Key);
                
                var responseAnswers = question.SelectMany(y => y.ResponseQuestions.Where(j => j.QuestionId == question.Key)
                    .SelectMany(x => x.ResponseAnswers.GroupBy(x => x.AnswerId)))
                    .Select(x => new { Key = x.Key, Parent = x })
                    .GroupBy(x => x.Key).Select(x => new AnswerQuantity
                    {
                        AnswerId = x.Key,
                        AnswerName = currentQuestion?.Answers.FirstOrDefault(y => y.Id == x.Key)?.Name,
                        Quantity = x.Count()
                    }).ToList();

                var emptyAnswers = currentQuestion?.Answers.Where(x => !responseAnswers.Any(y => y.AnswerId == x.Id)).Select(x => new AnswerQuantity
                {
                    AnswerId = x.Id,
                    AnswerName = x.Name,
                    Quantity = 0
                }).ToList();

                if (emptyAnswers?.Count > 0) responseAnswers.AddRange(emptyAnswers);

                return new ResponseQuestionAnswer
                {
                    QuestionId = question.Key,
                    QuestionName = currentQuestion?.Name,
                    AnswerQuantity = responseAnswers
                };
                }) ;

            return new ResponseDTO
            {
                ResponseQuantity = cuantity,
                SurveyTitle = record.Select(x => x.Survey.Title).FirstOrDefault() ?? "",
                SurveyId = record.Select(x => x.Survey.Id).FirstOrDefault(),
                QuestionAnswer = questionAnswer.ToList()
            };
        }
        #endregion

        #region Survey Has Responses
        /// <summary>
        /// Survey Has Responses
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        public async Task<bool> HasAnswers(int surveyId)
        {
            var record = (await All())
                  .Where(r => r.SurveyId == surveyId).FirstOrDefault();
            if (record == null)
                return false;
            return true;
        }
        #endregion

        #region Get Total Responses
        /// <summary>
        /// Get Total Responses
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<long> TotalResponses(int userId)
        {
            var surveys = (await _surveyService.Value.GetAll(userId)).Select(s => s.Id);
            var record = (await All())
                 .Where(r => surveys.Contains(r.SurveyId)).Count();

            return record;
        }
        #endregion
    }
}
