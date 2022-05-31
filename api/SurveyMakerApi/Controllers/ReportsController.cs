using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyMakerApi.Core.Controllers;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : MainController
    {
        private readonly IReportsService _reportsService;
        private readonly IMapper _mapper;
        public ReportsController(IReportsService reportsService, IMapper mapper)
        {
            _reportsService = reportsService;
            _mapper = mapper;
        }
        #region Get Report By Survey Id
        /// <summary>
        /// Get Report By Survey Id
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{surveyId}")]
        public async Task<IActionResult> ReportStatistics(int surveyId)
        {
            var newResponse = await _reportsService.GetStatistics(GetUserId(), surveyId);
            return Ok(newResponse);
        }
        #endregion

        #region Generate Report in XLS
        /// <summary>
        /// Generate Report in XLS
        /// </summary>
        /// <param name="surveyId"></param>
        /// <returns></returns>

        [Authorize]
        [HttpGet("{surveyId}/report")]
        public async Task<IActionResult> GetReport(int surveyId)
        {
            var newResponse = await _reportsService.GetReport(GetUserId(), surveyId);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "Report.xlsx";
            return File(newResponse, contentType, fileName);
        }
        #endregion

        #region Get KPIs
        /// <summary>
        /// Get KPIs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("kpi")]
        public async Task<IActionResult> GetKpis()
        {
            var newResponse = await _reportsService.GetKpis(GetUserId());
            return Ok(newResponse);
        }
        #endregion
    }
}
