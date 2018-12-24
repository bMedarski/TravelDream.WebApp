using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TravelDream.WebApp.Controllers
{
	using Microsoft.AspNetCore.Diagnostics;
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
			var errorModel = new ErrorViewModel {Name = "Not Found", RequestId = "404", ShowRequestId = true};
			return this.View(errorModel);
		}
	}
}