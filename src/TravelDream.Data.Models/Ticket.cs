namespace TravelDream.Data.Models
{
	using Common;

	public class Ticket:BaseModel<int>
	{
		public Seat Seat { get; set; }

		public decimal Price => this.Seat.Price * this.Discount.Percent;

		public Discount Discount { get; set; }

		public User Buyer { get; set; }
	}
}
