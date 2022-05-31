using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyMakerApi.Core.Controllers;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : MainController
    {
        private readonly ISurveysService _surveysService;
        private readonly ISurveyStatusesService _surveyStatusesService;
        private readonly IResponsesService _responsesService;
        private readonly IMapper _mapper;
        public SurveysController(ISurveysService surveysService, IResponsesService responsesService, ISurveyStatusesService surveyStatuses, IMapper mapper)
        {
            _surveysService = surveysService;
            _surveyStatusesService = surveyStatuses;
            _mapper = mapper;
            _responsesService = responsesService;
        }

        #region Get All Surveys
        /// <summary>
        /// Get All Surveys. Filter by status
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int statusId)
        {
            return Ok(await _surveysService.GetAll(GetUserId(), statusId));
        }
        #endregion

        #region Get Survey By Id
        /// <summary>
        /// Get Survey By Id
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{surveyId}", Name = "GetSurvey")]
        public async Task<IActionResult> Get(int surveyId)
        {
            var result = await _surveysService.GetById(GetUserId(), surveyId);

            var surveyToReturn = _mapper.Map<SurveyDto>(result);
            surveyToReturn.HasResponses = await _responsesService.HasAnswers(surveyId);
            return Ok(surveyToReturn);
        }
        #endregion

        #region Get Survey By Link
        /// <summary>
        /// Get Survey By Link
        /// </summary>
        /// <param name="surveyLink"></param>
        /// <returns></returns>
        [HttpGet("{surveyLink}/link", Name = "GetSurveyByLink")]
        public async Task<IActionResult> GetByLink(Guid surveyLink)
        {
            var result = await _surveysService.GetByLink(surveyLink);

            var surveyToReturn = _mapper.Map<SurveyDto>(result);
            return Ok(surveyToReturn);
        }
        #endregion

        #region Create Survey
        /// <summary>
        /// Create Survey
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyInputDTO input)
        {
            var newSurvey = await _surveysService.Create(input, GetUserId());
            
            var surveyToReturn = _mapper.Map<SurveyDto>(newSurvey);

            return CreatedAtAction(nameof(Get), new
            {
                surveyId = newSurvey.Id
            }, surveyToReturn);
        }
        #endregion

        #region Create Survey as Draft
        /// <summary>
        /// Create Survey as Draft
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("draft")]
        public async Task<IActionResult> CreateDraft([FromBody] SurveyInputDTO input)
        {
            var newSurvey = await _surveysService.Create(input, GetUserId(), true);

            var surveyToReturn = _mapper.Map<SurveyDto>(newSurvey);

            return CreatedAtAction(nameof(Get), new
            {
                surveyId = newSurvey.Id
            }, surveyToReturn);
        }
        #endregion

        #region Edit Survey and Publish
        [Authorize]
        [HttpPut("{surveyId}")]
        public async Task<IActionResult> Edit(int surveyId, [FromBody] SurveyInputDTO input)
        {
            var result = await _surveysService.Edit(GetUserId(), surveyId, input);

            var surveyToReturn = _mapper.Map<SurveyDto>(result);
            return Ok(surveyToReturn);
        }
        #endregion

        #region Edit Survey and Save as Draft
        [Authorize]
        [HttpPut("{surveyId}/draft")]
        public async Task<IActionResult> EditDraft(int surveyId, [FromBody] SurveyInputDTO input)
        {
            var result = await _surveysService.EditDraft(GetUserId(), surveyId, input);

            var surveyToReturn = _mapper.Map<SurveyDto>(result);
            return Ok(surveyToReturn);
        }
        #endregion

        #region Mark Survey as Active
        /// <summary>
        /// Mark Survey as Active
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{surveyId}/active")]
        public async Task<IActionResult> MarkAsActive(int surveyId)
        {
            var survey = await _surveysService.MarkAsActive(surveyId);

            return Ok(survey);
        }
        #endregion

        #region Mark Survey as Completed
        /// <summary>
        /// Mark Survey as Completed
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{surveyId}/completed")]
        public async Task<IActionResult> MarkAsCompleted(int surveyId)
        {
            var survey = await _surveysService.MarkAsCompleted(surveyId);

            return Ok(survey);
        }
        #endregion
    }
}
