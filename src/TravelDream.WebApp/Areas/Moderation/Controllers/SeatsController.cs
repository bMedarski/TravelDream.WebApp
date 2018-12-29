namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.ViewModels.SeatModels;
	using WebApp.Controllers;

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
		//[HttpPost]
		//public IActionResult AddSeats(AddSeatsInputViewModel model)
		//{

		//}
	}
}
