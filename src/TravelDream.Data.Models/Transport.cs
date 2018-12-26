namespace TravelDream.Data.Models
{
	using System.Collections.Generic;
	using Common;
	using Enums;

	public class Transport:BaseModel<int>
	{
		public Transport()
		{
			this.Seats = new HashSet<Seat>();
		}
		public ICollection<Seat> Seats { get; set; }
		public TransportType TransportType { get; set; }
		public Company Company { get; set; }
		public int SeatsAvailable { get; set; }
	}
}
