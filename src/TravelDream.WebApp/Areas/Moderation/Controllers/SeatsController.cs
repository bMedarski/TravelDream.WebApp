namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.SeatModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.ModerationAreaText)]
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

			var result = await this._seatsService.AddSeats(model);

			return this.RedirectToAction("AddSeats", "Seats", new {area = @GlobalConstants.ModerationAreaText});
		}
	}
}
