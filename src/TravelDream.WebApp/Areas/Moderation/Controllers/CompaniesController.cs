using Microsoft.AspNetCore.Mvc;

namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Services.DataServices.Contracts;

	public class CompaniesController : Controller
    {
	    private readonly ICompaniesService _companiesService;

	    public CompaniesController(ICompaniesService companiesService)
	    {
		    this._companiesService = companiesService;
	    }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}