namespace TravelDream.WebApp.Middleware
{
	using System.Threading.Tasks;
	using Data;
	using Data.Common;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Services.Utilities.Constants;

	public class Seeder
	{
		private readonly RequestDelegate _next;
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<User> _userManager;

		public Seeder(RequestDelegate next)
		{
			this._next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext, TravelDreamDbContext dbContext,RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
		{
			this._roleManager = roleManager;
			this._userManager = userManager;
			this.SeedRoles(roleManager,userManager);
			await this.SeedAdmin(roleManager, userManager);
			await this._next(httpContext);
		}
		public void SeedRoles(RoleManager<IdentityRole> rm,UserManager<User> um)
		{
			if (!rm.RoleExistsAsync
				(GlobalConstants.UserRoleText).Result)
			{
				IdentityRole role = new IdentityRole(GlobalConstants.UserRoleText);
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}			
			if (!rm.RoleExistsAsync
				(GlobalConstants.ModeratorRoleText).Result)
			{
				IdentityRole role = new IdentityRole {Name = GlobalConstants.ModeratorRoleText};
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}
			if (!rm.RoleExistsAsync
				(GlobalConstants.AdminRoleText).Result)
			{
				IdentityRole role = new IdentityRole {Name = GlobalConstants.AdminRoleText};
				IdentityResult roleResult = rm.CreateAsync(role).Result;
			}
		}
		public async Task<User> SeedAdmin(RoleManager<IdentityRole> rm, UserManager<User> um)
		{
			var isAdmin = await um.FindByNameAsync(GlobalConstants.AdminRoleText) == null;

			if (isAdmin)
			{
				var admin = new User
				{
					UserName = GlobalConstants.AdminRoleText,
					Email = GlobalConstants.AdminRoleText
				};

				await um.CreateAsync(admin, GlobalConstants.AdminRoleText);
				await um.AddToRoleAsync(admin,
					GlobalConstants.AdminRoleText);

				return admin;
			}

			return null;
		}
	}
}
