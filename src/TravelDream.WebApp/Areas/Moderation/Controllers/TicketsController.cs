namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.ViewModels.TicketModels;
	using WebApp.Controllers;

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
	    public IActionResult Add(InputTicketViewModel model)
	    {
		    return this.View();
	    }
    }
}