namespace TravelDream.WebApp.Areas.Administration.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.CompanyModels;

	[Area(GlobalConstants.AdministrationAreaText)]
	[Authorize(Roles = GlobalConstants.AdminRoleText)]
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

		    this.TempData[GlobalConstants.SuccessMessageKey] = "Company" + GlobalConstants.SuccessfullyAddedMessage;
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