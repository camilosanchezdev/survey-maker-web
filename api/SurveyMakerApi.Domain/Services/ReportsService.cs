using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SurveyMakerApi.Core.Exceptions;
using SurveyMakerApi.Domain.DTOs;
using SurveyMakerApi.Domain.Services.Interfaces;

namespace SurveyMakerApi.Domain.Services
{

    public class ReportsService : IReportsService
    {
        private readonly IMapper _mapper;
        private readonly Lazy<ISurveysService> _surveyService;
        private readonly Lazy<IResponsesService> _responsesService;
        public ReportsService(IServiceProvider serviceProvider, IMapper mapper)
        {
            _mapper = mapper;
            _surveyService = new Lazy<ISurveysService>(() => serviceProvider.GetRequiredService<ISurveysService>());
            _responsesService = new Lazy<IResponsesService>(() => serviceProvider.GetRequiredService<IResponsesService>());
        }

        #region Get Statistics
        /// <summary>
        /// Get Statistics
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="surveyId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<object> GetStatistics(int userId, int surveyId)
        {
            var record = (await _responsesService.Value.GetById(userId, surveyId));

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
        public async Task<byte[]> GetReport(int userId, int surveyId)
        {
            var record = (await _responsesService.Value.GetById(userId, surveyId));
            if (record == null)
            {
                throw new NotFoundException();
            }
            return CreateDocument(record);
        }
        #endregion

        #region Create Document XLS
        /// <summary>
        /// Create Document XLS
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private byte[] CreateDocument(ResponseDTO record)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet excelSheet = workbook.CreateSheet("Report");
            IRow row = excelSheet.CreateRow(0);
              
               
            // Styles
            var boldFont = workbook.CreateFont();
            boldFont.IsBold = true;
            // Cell style 1
            var cellStyle1 = workbook.CreateCellStyle();
            cellStyle1.Alignment = HorizontalAlignment.Center;
            cellStyle1.SetFont(boldFont);
            cellStyle1.FillForegroundColor = IndexedColors.SeaGreen.Index;
            cellStyle1.FillPattern = FillPattern.SolidForeground;
            cellStyle1.BorderBottom = BorderStyle.Thin;
            cellStyle1.BorderTop = BorderStyle.Thin;
            cellStyle1.BorderRight = BorderStyle.Thin;
            cellStyle1.BorderLeft = BorderStyle.Thin;
          
            // Cell Style 2
            var cellStyle2 = workbook.CreateCellStyle();
            cellStyle2.SetFont(boldFont);
            cellStyle2.FillForegroundColor = IndexedColors.LightGreen.Index;
            cellStyle2.FillPattern = FillPattern.SolidForeground;
            cellStyle2.BorderBottom = BorderStyle.Thin;
            cellStyle2.BorderTop = BorderStyle.Thin;
            cellStyle2.BorderRight = BorderStyle.Thin;
            cellStyle2.BorderLeft = BorderStyle.Thin;

            // Cell Style 3
            var cellStyle3 = workbook.CreateCellStyle();
            cellStyle3.BorderBottom = BorderStyle.Thin;
            cellStyle3.BorderTop = BorderStyle.Thin;
            cellStyle3.BorderRight = BorderStyle.Thin;
            cellStyle3.BorderLeft = BorderStyle.Thin;

            // Data
            var cell = row.CreateCell(0);
            cell.SetCellValue("General Data");
            cell.CellStyle = cellStyle1;
            NPOI.SS.Util.CellRangeAddress cra = new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 1);
            excelSheet.AddMergedRegion(cra);

            int rowIndex = 1;
            row = excelSheet.CreateRow(rowIndex);
            int cellIndex = 0;
            cell = row.CreateCell(cellIndex);
                cell.SetCellValue("Survey Title");
            cell.CellStyle = cellStyle2;
            cellIndex++;
            cell = row.CreateCell(cellIndex);
            cell.SetCellValue(record.SurveyTitle);
            cell.CellStyle = cellStyle3;

            rowIndex++;
            row = excelSheet.CreateRow(rowIndex);
            cellIndex = 0;
            cell = row.CreateCell(cellIndex);
                cell.SetCellValue("Survey Id");
            cell.CellStyle = cellStyle2;
            cellIndex++;
            cell = row.CreateCell(cellIndex);
            cell.SetCellValue(record.SurveyId);
            cell.CellStyle = cellStyle3;

            rowIndex++;
            row = excelSheet.CreateRow(rowIndex);
            cellIndex = 0;
            cell = row.CreateCell(cellIndex);
            cell.SetCellValue("Surveyed");
            cell.CellStyle = cellStyle2;
            cellIndex++;
            cell = row.CreateCell(cellIndex);
            cell.SetCellValue(record.ResponseQuantity);
            cell.CellStyle = cellStyle3;
            rowIndex++;
            rowIndex++;
            row = excelSheet.CreateRow(rowIndex);

            foreach (var question in record.QuestionAnswer)
            {
                cellIndex = 0;
                cell = row.CreateCell(cellIndex);
                cell.SetCellValue("Question");
                cell.CellStyle = cellStyle2;
                cellIndex++;
                cell = row.CreateCell(cellIndex);
                cell.SetCellValue(question.QuestionName);
                cell.CellStyle = cellStyle3;
                rowIndex++;
                row = excelSheet.CreateRow(rowIndex);
                cellIndex = 0;
                cell = row.CreateCell(cellIndex);
                cell.SetCellValue("Answer");
                cell.CellStyle = cellStyle2;
                cellIndex++;
                cell = row.CreateCell(cellIndex);
                cell.SetCellValue("Quantity");
                cell.CellStyle = cellStyle2;
                foreach (var answer in question.AnswerQuantity)
                {
                    rowIndex++;
                    row = excelSheet.CreateRow(rowIndex);
                    cellIndex = 0;
                    cell = row.CreateCell(cellIndex);
                    cell.SetCellValue(answer.AnswerName);
                    cell.CellStyle = cellStyle3;
                    cellIndex++;
                    cell = row.CreateCell(cellIndex);
                    cell.SetCellValue(answer.Quantity);
                    cell.CellStyle = cellStyle3;

                }
                rowIndex++;
                rowIndex++;
                row = excelSheet.CreateRow(rowIndex);
            }

            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                var content = stream.ToArray();
                return content;
                    
            }

        }
        #endregion

        #region Get KPIs
        /// <summary>
        /// Get KPIs
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<KpiDTO> GetKpis(int userId) 
        {
            var totalSurveys = await _surveyService.Value.GetTotalSurveys(userId);
            var totalSurveysActive = await _surveyService.Value.GetTotalSurveysActive(userId);
            var totalSurveysCompleted = await _surveyService.Value.GetTotalSurveysCompleted(userId);
            var totalResponses = await _responsesService.Value.TotalResponses(userId);

            return new KpiDTO
            {
                TotalSurveys = totalSurveys,
                TotalSurveysActive = totalSurveysActive,
                TotalSurveysCompleted = totalSurveysCompleted,
                TotalResponses = totalResponses
            };
        }
        #endregion
    }
}
