namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.Utilities.Constants;
	using Services.ViewModels.LocationModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class LocationsController : BaseController
    {
        public IActionResult Add()
        {
            return this.View();
        }
		[HttpPost]
	    public IActionResult Add(InputLocationViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    return this.View();
	    }
    }
}