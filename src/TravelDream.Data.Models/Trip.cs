namespace TravelDream.Data.Models
{
	using System;

	public class Trip
	{
		public int Id { get; set; }

		public Transport Transport { get; set; }

		public City Destination { get; set; }

		public City Departure { get; set; }

		public DateTime DepartureTime { get; set; }

		public DateTime ArrivalTime { get; set; }

	}
}
