namespace TravelDream.Data.Models
{
	using Common;
	using Enums;

	public class Seat:BaseModel<int>
	{
		public decimal Price { get; set; }
		public int Number { get; set; }
		public TransportType Type { get; set; }
	}
}
