namespace TravelDream.WebApp.Areas.Transportations.Controllers
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.SeatModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.TransportationsAreaText)]
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
			this.TempData[GlobalConstants.SuccessMessageKey] = model.SeatCount + GlobalConstants.SuccessfullyAddedSeatsMessage;
			return this.Redirect("AddSeats");
		}
	}
}
