using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsesController : ControllerBase
    {
        private readonly IResponsesService _responseService;
        private readonly ISurveyStatusesService _surveyStatusesService;
        private readonly IMapper _mapper;
        public ResponsesController(IResponsesService responseService, ISurveyStatusesService surveyStatuses, IMapper mapper)
        {
            _responseService = responseService;
            _surveyStatusesService = surveyStatuses;
            _mapper = mapper;
        }
        #region Create New Response
        /// <summary>
        /// Create New Response
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ResponseInputDTO input)
        {
            var newResponse = await _responseService.Create(input);
            return Ok();
        }
        #endregion
    }
}