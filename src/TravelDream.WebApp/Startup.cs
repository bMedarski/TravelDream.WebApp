﻿namespace TravelDream.WebApp
{
	using Data;
	using Data.Common;
	using Extensions;
	using Filters;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Newtonsoft.Json.Serialization;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<TravelDreamDbContext>(options =>
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User,IdentityRole>(
					options =>
					{
						options.Password.RequireDigit = false;
						options.Password.RequireLowercase = false;
						options.Password.RequireNonAlphanumeric = false;
						options.Password.RequireUppercase = false;
						options.Password.RequiredLength = 3;
						options.Password.RequiredUniqueChars = 1;
					}
				)			
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<TravelDreamDbContext>();

			services.AddMvc(
					options =>
					{
						options.Filters.Add(typeof(ValidateModelStateAttribute));
					}
				)
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options =>
					options.SerializerSettings.ContractResolver = new DefaultContractResolver());


			services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

			services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = $"/Administration/Users/Login";
				options.LogoutPath = $"/Administration/Users/Logout";
				options.AccessDeniedPath = $"/Administration/Users/AccessDenied";
			});
		}



		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseStatusCodePagesWithReExecute("/Errors/Status/{0}");
				//app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseStatusCodePagesWithReExecute("/Errors/Status/{0}");
				app.UseHsts();
			}
			app.UseSeeder();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name : "areas",
					template : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}