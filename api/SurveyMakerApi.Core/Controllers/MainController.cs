using Microsoft.AspNetCore.Mvc;

namespace SurveyMakerApi.Core.Controllers
{
    public class MainController : ControllerBase
    {
        protected int GetUserId()
        {
            return Convert.ToInt32(GetClaim("user_id"));
        }

        protected string GetClaim(string field)
        {
            return User.Claims.First(c => c.Type.Equals(field)).Value;
        }
    }
}
