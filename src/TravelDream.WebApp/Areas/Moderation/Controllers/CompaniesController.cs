using Microsoft.AspNetCore.Mvc;

namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CompanyModels;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
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
	    public async Task<IActionResult> Add(InputCompanyViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }
		    var companyId = await this._companiesService.Add(model);

		    this.TempData["Message"] = "Company was added successfully";
		    return this.Redirect("Add");
	    }
	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var companies = this._companiesService.GetAll().ToList();
		    return this.Json(companies);
	    }
    }
}