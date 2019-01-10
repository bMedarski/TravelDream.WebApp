using Microsoft.AspNetCore.Builder;

namespace TravelDream.WebApp.Middleware
{
	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseAntiforgeryTokens(this IApplicationBuilder app)
		{
			return app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
		}
	}
}