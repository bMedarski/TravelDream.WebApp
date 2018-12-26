namespace TravelDream.Data.Models
{
	using Common;
	using Enums;

	public class Transport:BaseModel<int>
	{	
		public int SeatsCount { get; set; }
		public TransportType TransportType { get; set; }
		public Company Company { get; set; }
		public int SeatsAvailable { get; set; }
	}
}
