namespace TravelDream.WebApp.Areas.Moderation.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using WebApp.Controllers;

	public class TransportsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}