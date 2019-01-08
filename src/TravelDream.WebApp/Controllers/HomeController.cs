namespace TravelDream.WebApp.Controllers
{
	using System;
	using System.Diagnostics;
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.ViewModels;

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class HomeController : BaseController
	{
		private readonly ITripsService _tripsService;

		public HomeController(ITripsService tripsService)
		{
			this._tripsService = tripsService;
		}
		public IActionResult Index()
		{
			return this.View();
		}

		public IActionResult Error()
		{
			return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
		}
	}
}
