namespace TravelDream.WebApp.Areas.Locations.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CityModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.LocationsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class CitiesController : BaseController
	{
		private readonly ICitiesService _citiesService;
		private readonly ICountriesService _countriesService;

		public CitiesController(ICitiesService citiesService,ICountriesService countriesService)
		{
			this._citiesService = citiesService;
			this._countriesService = countriesService;
		}
		public IActionResult IsExist(string name)
		{
			bool exist = this._citiesService.IsExist(name);
			return this.Json(!exist);
		}
		public IActionResult Add()
		{
			return this.View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(InputCityViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}
			var result = await this._citiesService.Add(model);
			this.TempData[GlobalConstants.SuccessMessageKey] = $"{model.Name}" + GlobalConstants.SuccessfullyAddedMessage;
			return this.Redirect("Add");
		}
		[HttpGet]
		public JsonResult GetAll()
		{
			var cities = this._citiesService.GetAll().ToList();
			return this.Json(cities);
		}

		[HttpPost]
		public JsonResult GetAllByCountry(int country, int transportType)
		{
			var cities = this._citiesService.GetAllByCountry(country,transportType).ToList();
			return this.Json(cities);
		}
	}
}