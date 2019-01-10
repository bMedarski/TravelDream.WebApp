namespace TravelDream.WebApp.Areas.Travels.Controllers
{
	using System.Threading.Tasks;
	using Data.Models;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using WebApp.Controllers;

	[Area(GlobalConstants.TravelsAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class TicketsController : BaseController
	{
		private readonly ITicketsService _ticketsService;
		private readonly ITripsService _tripsService;
		private readonly IDiscountsService _discountsService;
		private readonly UserManager<User> _userManager;

		public TicketsController(ITicketsService ticketsService,ITripsService tripsService,IDiscountsService discountsService,UserManager<User> userManager)
		{
			this._ticketsService = ticketsService;
			this._tripsService = tripsService;
			this._discountsService = discountsService;
			this._userManager = userManager;
		}

		public async Task<IActionResult> Add(int id,string seatType,int count , int discount)
		{
			var user = await this._userManager.GetUserAsync(this.User);
			var tickets = await this._ticketsService.Add(id,seatType,count,discount,user);
			return this.View(tickets);
		}
    }
}