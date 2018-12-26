namespace TravelDream.WebApp.Middleware
{
	using System.Threading.Tasks;
	using Data;
	using Data.Common;
	using Data.Models;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;
	using Services.DataServices.Contracts;
	using Services.Utilities.Constants;
	using Services.ViewModels.DiscountModels;

	public class Seeder
	{
		private readonly RequestDelegate _next;
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<User> _userManager;

		public Seeder(RequestDelegate next)
		{
			this._next = next;
		}
		public async Task InvokeAsync(HttpContext httpContext, TravelDreamDbContext dbContext,RoleManager<IdentityRole> roleManager,UserManager<User> userManager,IDiscountsService discountsService)
		{
			this._roleManager = roleManager;
			this._userManager = userManager;
			this.SeedRoles(roleManager,userManager);
			this.SeedDiscounts(discountsService);
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
		public void SeedDiscounts(IDiscountsService discountsService)
		{
			if (discountsService.All().Count==0)
			{
				var child = new InputDiscountViewModel
				{
					Name = InputModelsConstants.ChildDiscountText,
					Percent = InputModelsConstants.ChildDiscountPercent
				};
				var senior = new InputDiscountViewModel
				{
					Name = InputModelsConstants.SeniorDiscountText,
					Percent = InputModelsConstants.SeniorDiscountPercent
				};
				var student = new InputDiscountViewModel
				{
					Name = InputModelsConstants.StudentDiscountText,
					Percent = InputModelsConstants.StudentDiscountPercent
				};
				var normal = new InputDiscountViewModel
				{
					Name = InputModelsConstants.NormalDiscountText,
					Percent = InputModelsConstants.NormalDiscountPercent
				};
				discountsService.Add(child);
				discountsService.Add(senior);
				discountsService.Add(student);
				discountsService.Add(normal);
			}
		}
	}
}
