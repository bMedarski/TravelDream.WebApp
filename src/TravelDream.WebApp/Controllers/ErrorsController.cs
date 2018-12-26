namespace TravelDream.WebApp.Controllers
{
	using System.Net;
	using Microsoft.AspNetCore.Diagnostics;
	using Microsoft.AspNetCore.Mvc;
	using Services.ViewModels;

	public class ErrorsController : Controller
	{
		public IActionResult Index(int statusCode)
		{
			var feature = this.HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

			this.ViewBag.StatusCode = statusCode;
			this.ViewBag.OriginalPath = feature?.OriginalPath;
			this.ViewBag.OriginalQueryString = feature?.OriginalQueryString;

			return this.View();
		}

		public IActionResult Status(int status)
		{			
			var errorModel = new ErrorViewModel {Name = HttpStatusCode.NotFound.ToString(), RequestId =$"Status {status}" , ShowRequestId = true};
			return this.View(errorModel);
		}
	}
}