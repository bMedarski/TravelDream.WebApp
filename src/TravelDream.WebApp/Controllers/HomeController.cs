namespace TravelDream.WebApp.Controllers
{
	using System.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using Services.ViewModels;

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class HomeController : BaseController
	{
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
