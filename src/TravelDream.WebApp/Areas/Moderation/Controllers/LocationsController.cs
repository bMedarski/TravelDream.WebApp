namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.LocationModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class LocationsController : BaseController
    {
	    private readonly ILocationsService _locationsService;

	    public LocationsController(ILocationsService locationsService)
	    {
		    this._locationsService = locationsService;
	    }
	    public IActionResult IsExist(string name)
	    {
		    bool exist = this._locationsService.IsExist(name);
		    return this.Json(!exist);
	    }
        public IActionResult Add()
        {
            return this.View();
        }
		[HttpPost]
	    public async Task<IActionResult> Add(InputLocationViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    var result = await this._locationsService.Add(model);
		    this.TempData[GlobalConstants.SuccessMessageKey] = $"{model.Name} was added successfully";
		    return this.Redirect("Add");
	    }
	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var locations = this._locationsService.GetAll().ToList();
		    return this.Json(locations);
	    }
		//TODO put javascript in separate files 
		//TODO display selected menus only after ajax request

	    [HttpPost]
	    public JsonResult GetAllByCountry(int country, int transportType)
	    {
		    var locations = this._locationsService.GetAllByCountry(country,transportType).ToList();
		    return this.Json(locations);
	    }
    }
}