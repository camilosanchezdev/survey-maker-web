namespace SurveyMakerApi.Core.Exceptions
{
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException()
        {
        }

        public UnAuthorizedException(string message)
            : base(message)
        {
        }

        public UnAuthorizedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
