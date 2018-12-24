namespace TravelDream.Data
{
	using Common;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class TravelDreamDbContext :  IdentityDbContext<User>
	{
		public TravelDreamDbContext(DbContextOptions<TravelDreamDbContext> options)
			: base(options)
		{
		}
	}
}
