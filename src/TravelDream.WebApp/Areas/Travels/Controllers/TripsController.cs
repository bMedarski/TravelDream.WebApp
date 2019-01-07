namespace TravelDream.WebApp.Areas.Travels.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.TripModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.TravelsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TripsController : BaseController
    {
	    private readonly ITripsService _tripsService;

	    public TripsController(ITripsService tripsService)
	    {
		    this._tripsService = tripsService;
	    }
	    public IActionResult Add()
	    {
		    return this.View();
	    }

	    [HttpPost]
	    public async Task<IActionResult> Add(InputTripViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }
		    var result = await this._tripsService.Add(model);

		    this.TempData[GlobalConstants.SuccessMessageKey] = "Trip" + GlobalConstants.SuccessfullyAddedMessage;
		    return this.Redirect("Add");
	    }

	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var trips = this._tripsService.GetAll().ToList();
		    return this.Json(trips);
	    }
    }
}