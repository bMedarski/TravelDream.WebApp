namespace TravelDream.Data
{
	using Common;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class TravelDreamDbContext :  IdentityDbContext<User>
	{
		public TravelDreamDbContext(DbContextOptions<TravelDreamDbContext> options)
			: base(options)
		{
		}

		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Transport> Transports { get; set; }
		public DbSet<Seat> Seats { get; set; }
		public DbSet<Discount> Discounts { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Trip> Trips { get; set; }
		public DbSet<City> Cities { get; set; }
	}
}
