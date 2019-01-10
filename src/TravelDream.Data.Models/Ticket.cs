namespace TravelDream.Data.Models
{
	using Common;

	public class Ticket:BaseModel<int>
	{
		public Seat Seat { get; set; }

		public decimal Price { get; set; }

		public User Buyer { get; set; }
	}
}
