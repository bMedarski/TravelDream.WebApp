namespace TravelDream.Data.Models
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Identity;

	public class User : IdentityUser
	{
		public User()
		{
			this.Tickets = new HashSet<Ticket>();
		}
		public ICollection<Ticket> Tickets { get; set; }
	}
}
