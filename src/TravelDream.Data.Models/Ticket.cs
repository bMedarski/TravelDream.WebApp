namespace TravelDream.Data.Models
{
	using Common;

	public class Ticket:BaseModel<int>
	{
		public decimal Price { get; set; }
		public string SeatNumber { get; set; }
	}
}
