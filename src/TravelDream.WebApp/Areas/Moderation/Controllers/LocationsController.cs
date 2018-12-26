namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Services.Utilities.Constants;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	public class LocationsController : BaseController
    {
        public IActionResult Add()
        {
            return this.View();
        }
    }
}