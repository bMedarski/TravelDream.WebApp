namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Utilities.Constants;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TripsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}