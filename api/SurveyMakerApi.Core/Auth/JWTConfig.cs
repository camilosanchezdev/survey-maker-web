namespace SurveyMakerApi.Core.Auth
{
    public class JWTConfig
    {
        public JWTConfigDetails JWT { get; set; }
    }
    public class JWTConfigDetails
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ValidityTime { get; set; }
        public int RefreshTime { get; set; }
    }
}
