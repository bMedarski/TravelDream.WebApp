namespace TravelDream.WebApp.Areas.Administration.Controllers
{
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
	[Authorize(Roles = GlobalConstants.AdminRoleText)]
	public class UsersController : BaseController
	{
		private readonly IUsersService _usersService;
		private readonly SignInManager<User> _signInManager;

		public UsersController(IUsersService usersService, SignInManager<User> signInManager)
		{
			this._usersService = usersService;
			this._signInManager = signInManager;
		}

		public IActionResult Login()
		{
			return this.View();
		}

		[ValidateModelState]
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

			return this.StatusCode(404);
		}
		public IActionResult Register()
		{
			return this.View();
		}

		[HttpPost]
		[ValidateModelState]
		public IActionResult Register(InputRegisterViewModel model)
		{
			this._usersService.CreateUser(model);
			return this.RedirectToAction("Index", "Home", new { area = "" });
		}
		
		public IActionResult Logout()
		{
			this._usersService.LogoutUser();
			return this.RedirectToAction("Index", "Home", new { area = "" });
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