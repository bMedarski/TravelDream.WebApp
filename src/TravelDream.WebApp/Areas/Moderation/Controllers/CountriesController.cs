namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CountryModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
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
	    public IActionResult Add(InputCountryViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }
		    var countryId = this._countriesService.Add(model);
		    return this.RedirectToAction("Add", "Countries", new { area = @GlobalConstants.ModerationAreaText });
	    }
    }
}