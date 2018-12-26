namespace TravelDream.Data.Models
{
	using Common;
	using Enums;

	public class Seat:BaseModel<int>
	{
		public decimal Price { get; set; }
		public string Row { get; set; }
		public string Number { get; set; }
		public TransportType Type { get; set; }
	}
}
