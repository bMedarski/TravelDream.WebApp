namespace TravelDream.Services.DataServices
{
	using System.Threading.Tasks;
	using AutoMapper;
	using Contracts;
	using Data;
	using Data.Common;
	using Data.Models;
	using Microsoft.AspNetCore.Identity;
	using Utilities.Constants;
	using ViewModels.UserModels;

	public class UsersService:IUsersService
	{
		private readonly IMapper _autoMapper;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly TravelDreamDbContext _context;

		private SignInManager<User> SignInManager { get; }
		private UserManager<User> UserManager { get; }

		public UsersService(TravelDreamDbContext context,RoleManager<IdentityRole>roleManager,SignInManager<User> signInManager, UserManager<User> userManager,IMapper autoMapper)
		{
			this._context = context;
			this._roleManager = roleManager;
			this._autoMapper = autoMapper;
			this.SignInManager = signInManager;
			this.UserManager = userManager;
		}
		public async Task<IdentityResult> CreateUser(InputRegisterViewModel model)
		{
			var user = this._autoMapper.Map<User>(model);
			var result = await this.UserManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				await this.UserManager.AddToRoleAsync(user,
					GlobalConstants.UserRoleText);
				await this.SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
				return result;
			}
			return result;
		}
		public async void LogoutUser()
		{
			await this.SignInManager.SignOutAsync();
		}

		//public IList<AdminPanelUsersViewModel> AdminPanelUsers()
		//{
		//	var users = new List<AdminPanelUsersViewModel>();
		//	foreach (var u in this.UserManager.Users.ToList())
		//	{
		//		var user = new AdminPanelUsersViewModel
		//		{
		//			Username = u.UserName,
		//			Id = u.Id
		//		};
		//		var roleId = this.context.UserRoles.Where(r => r.UserId == u.Id).FirstOrDefault();
		//		if (roleId != null)
		//		{
		//			user.Role = this.roleManager.Roles.Where(r => r.Id == roleId.RoleId).FirstOrDefault().Name;
		//		}

		//		users.Add(user);
		//	}
		//	return users;
		//}

		//public void Promote(string id)
		//{
		//	var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
		//	this.UserManager.AddToRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		//}

		//public void Demote(string id)
		//{
		//	var user = this.UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
		//	this.UserManager.RemoveFromRoleAsync(user,GlobalConstants.AdminRoleText).GetAwaiter().GetResult();
		//}
	}
}
