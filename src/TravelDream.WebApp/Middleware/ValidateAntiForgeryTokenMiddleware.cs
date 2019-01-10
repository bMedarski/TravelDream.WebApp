using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace TravelDream.WebApp.Middleware
{
	public class ValidateAntiForgeryTokenMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IAntiforgery _antiforgery;

		public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
		{
			this._next = next;
			this._antiforgery = antiforgery;
		}

		public async Task Invoke(HttpContext context)
		{
			if (HttpMethods.IsPost(context.Request.Method))
			{
				await this._antiforgery.ValidateRequestAsync(context);
			}

			await this._next(context);
		}
	}
}