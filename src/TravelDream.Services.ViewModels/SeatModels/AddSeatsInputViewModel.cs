namespace TravelDream.Services.ViewModels.SeatModels
{
	using Data.Models.Enums;

	public class AddSeatsInputViewModel
	{
		public int Count { get; set; }
		public SeatType SeatType { get; set; }
		public int TransportId { get; set; }
		public decimal Price { get; set; }
	}
}
