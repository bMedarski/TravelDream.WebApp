namespace TravelDream.Data.Models
{
	using System.Collections.Generic;
	using Common;

	public class Company:BaseModel<int>
	{
		public Company()
		{
			this.Transports = new HashSet<Transport>();
		}
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public int PhoneNumber { get; set; }
		public Country Country { get; set; }
		public ICollection<Transport> Transports { get; set; }
	}
}
