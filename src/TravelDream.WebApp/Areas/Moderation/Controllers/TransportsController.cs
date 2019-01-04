namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.TransportModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
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
	    public IActionResult Add(InputTransportViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
				return this.View(model);
		    }

		    var transport = this._transportsService.Add(model);

		    return this.RedirectToAction("Add", "Transports", new {area = @GlobalConstants.ModerationAreaText});
	    }

	    [HttpGet]
	    public JsonResult GetAll()
	    {
		    var transports = this._transportsService.GetAll().ToList();
		    return this.Json(transports);
	    }
    }
}