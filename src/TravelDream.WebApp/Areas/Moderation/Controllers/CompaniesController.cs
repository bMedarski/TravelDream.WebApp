using Microsoft.AspNetCore.Mvc;

namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Linq;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CompanyModels;

	[Area(GlobalConstants.ModerationAreaText)]
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

		[HttpPost]
	    public IActionResult Add(InputCompanyViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    var companyId = this._companiesService.Add(model);

		    return this.RedirectToAction("Add", "Companies", new {area = @GlobalConstants.ModerationAreaText});
	    }
	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var companies = this._companiesService.GetAll().ToList();
		    return this.Json(companies);
	    }
    }
}