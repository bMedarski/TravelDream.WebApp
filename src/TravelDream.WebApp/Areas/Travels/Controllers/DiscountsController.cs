namespace TravelDream.WebApp.Areas.Travels.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using WebApp.Controllers;

	[Area(GlobalConstants.TravelsAreaText)]
	[Authorize]
	public class DiscountsController : BaseController
    {
	    private readonly IDiscountsService _discountsService;

	    public DiscountsController(IDiscountsService discountsService)
	    {
		    this._discountsService = discountsService;
	    }

        public IActionResult GetAll()
        {
	        var discounts = this._discountsService.All();
	        return this.Json(discounts);
        }
    }
}