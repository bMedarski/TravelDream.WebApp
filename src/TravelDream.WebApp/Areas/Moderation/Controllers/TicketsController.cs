namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.TicketModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TicketsController : BaseController
    {
		private readonly ITicketsService _ticketsService;

		public TicketsController(ITicketsService ticketsService)
	    {
			this._ticketsService = ticketsService;
		}

	    public IActionResult Add()
	    {
		    return this.View();
	    }

		[HttpPost]
	    public  async Task<IActionResult> Add(InputTicketViewModel model)
	    {
		    if (!this.ModelState.IsValid)
		    {
			    return this.View(model);
		    }

		    //var companyId = await this._ticketsService.Add(model);

		    this.TempData[GlobalConstants.SuccessMessageKey] = "Ticket was added successfully";
		    return this.Redirect("Add");
	    }
    }
}