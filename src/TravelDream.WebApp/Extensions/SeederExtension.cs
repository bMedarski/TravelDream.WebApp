namespace TravelDream.WebApp.Extensions
{
	using Microsoft.AspNetCore.Builder;
	using Middleware;

	public static class SeederExtension
	{		public static IApplicationBuilder UseSeeder(
			this IApplicationBuilder builder) => builder.UseMiddleware<Seeder>();
	}
}
