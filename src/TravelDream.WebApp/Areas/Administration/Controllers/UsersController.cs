namespace TravelDream.WebApp.Areas.Administration.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }
    }
}