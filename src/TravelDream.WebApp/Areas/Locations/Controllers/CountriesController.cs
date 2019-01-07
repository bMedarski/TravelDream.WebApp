namespace TravelDream.WebApp.Areas.Locations.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CountryModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.LocationsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class CountriesController : BaseController
    {
	    private readonly ICountriesService _countriesService;

	    public CountriesController(ICountriesService countriesService)
	    {
		    this._countriesService = countriesService;
	    }

	    public IActionResult IsExist(string name)
	    {
		    bool exist = this._countriesService.IsExist(name);
		    return this.Json(!exist);
	    }

        public IActionResult Add()
        {
            return this.View();
        }

		[HttpPost]
	    public async Task<IActionResult> Add(InputCountryViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }
		    var result = await this._countriesService.Add(model);

		    this.TempData[GlobalConstants.SuccessMessageKey] = $"{model.Name}" + GlobalConstants.SuccessfullyAddedMessage;
		    return this.Redirect("Add");
	    }

	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var countries = this._countriesService.GetAll().ToList();
		    return this.Json(countries);
	    }
    }
}