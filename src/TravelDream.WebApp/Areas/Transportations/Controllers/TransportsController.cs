namespace TravelDream.WebApp.Areas.Transportations.Controllers
{
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.TransportModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.TransportationsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TransportsController : BaseController
    {
		private readonly ITransportsService _transportsService;

		public TransportsController(ITransportsService transportsService)
	    {
			this._transportsService = transportsService;
		}

        public IActionResult Add()
        {
            return this.View();
        }

		[HttpPost]
	    public async Task<IActionResult> Add(InputTransportViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
				return this.View(model); 
		    }
		    var transport = await this._transportsService.Add(model);

		    this.TempData[GlobalConstants.SuccessMessageKey] = "Transport" + GlobalConstants.SuccessfullyAddedMessage;
		    return this.Redirect("Add");
	    }

	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var transports = this._transportsService.GetAll().ToList();
		    return this.Json(transports);
	    }

	    [HttpPost]
	    public JsonResult GetAllByType(int transportType)
	    {
		    var transports = this._transportsService.GetAllByType(transportType).ToList();
		    return this.Json(transports);
	    }
	    [HttpPost]
	    public JsonResult GetAllByTypeAvailable(int transportType)
	    {
		    var transports = this._transportsService.GetAllByTypeAvailable(transportType);
		    return this.Json(transports);
	    }
    }
}