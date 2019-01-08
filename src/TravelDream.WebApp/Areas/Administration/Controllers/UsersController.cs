namespace TravelDream.WebApp.Areas.Administration.Controllers
{
	using System.Threading;
	using System.Threading.Tasks;
	using Data.Common;
	using Filters;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.UserModels;
	using WebApp.Controllers;

	[Area(GlobalConstants.AdministrationAreaText)]
	public class UsersController : BaseController
	{
		private readonly IUsersService _usersService;
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManager;

		public UsersController(IUsersService usersService, SignInManager<User> signInManager,UserManager<User> userManager)
		{
			this._usersService = usersService;
			this._signInManager = signInManager;
			this._userManager = userManager;
		}

		public IActionResult Login()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(InputLoginViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			var result = await this._signInManager.PasswordSignInAsync(model.Username,
				model.Password, model.RememberMe, false);

			if (result.Succeeded)
			{
				return this.RedirectToAction("Index", "Home", new { area = "" });
			}
			else
			{
				
				this.ModelState.AddModelError("", InputModelsConstants.WrongUsernameOrPasswordErrorMessage);
				return this.View(model);
			}
		}
		public IActionResult Register()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(InputRegisterViewModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}

			await this._usersService.CreateUser(model);
			return this.RedirectToAction("Index", "Home", new { area = "" });
		}
		
		public IActionResult Logout()
		{
			this._usersService.LogoutUser();
			return this.RedirectToAction("Index", "Home", new { area = "" });
		}

		public IActionResult IsUserAvailable(string username)
		{
			var user = this._userManager.FindByNameAsync(username);
			if (user.Result == null)
			{
				return this.Json(true);
			}
			return this.Json(false);
		}

		//[Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult AdminPanel()
		//{
		//	var users = new AdminPanelUsersListViewModel{Users = this.AccountsService.AdminPanelUsers()};
		//	return this.View(users);
		//}
		//   [Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult Demote(string id)
		//   {
		//    this.AccountsService.Demote(id);
		//    return this.RedirectToAction("AdminPanel");
		//   }
		//   [Authorize(Roles = GlobalConstants.AdminRoleText)]
		//   public IActionResult Promote(string id)
		//   {
		//    this.AccountsService.Promote(id);
		//    return this.RedirectToAction("AdminPanel");
		//   }
	}
}