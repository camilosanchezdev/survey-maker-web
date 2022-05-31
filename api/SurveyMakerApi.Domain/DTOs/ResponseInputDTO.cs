namespace SurveyMakerApi.Domain.DTOs
{
    public class ResponseInputDTO
    {
        public Guid Link { get; set; }
        public List<ResponseQuestionInputDTO> Answers { get; set; }
    }
}
