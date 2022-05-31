namespace SurveyMakerApi.Persistence.Aggregates
{
    public partial class SurveyStatus
    {
        public enum Accessors
        {
            Active = 1,
            Draft = 2,
            Completed = 3
        }
    }
}
