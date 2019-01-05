namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Net;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.SeatModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
	[Authorize(Roles = GlobalConstants.AdministrationModerationAreaText)]
	public class SeatsController:BaseController
	{
		private readonly ISeatsService _seatsService;

		public SeatsController(ISeatsService seatsService)
		{
			this._seatsService = seatsService;
		}

		public IActionResult AddSeats()
		{
			return this.View();
		}
		[HttpPost]
		public async Task<IActionResult> AddSeats(AddSeatsInputViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);

			}
			var result = await this._seatsService.AddSeats(model);

			//TODO da se iznesat v konstanti
			this.TempData["Message"] = model.SeatCount + " seats were added successfully";
			return this.Redirect("AddSeats");
		}
	}
}
