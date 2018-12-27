namespace TravelDream.Services.ViewModels.SeatModels
{
	using Data.Models.Enums;

	public class InputSeatViewModel
	{
		public decimal Price { get; set; }
		public string Row { get; set; }
		public string Number { get; set; }
		public SeatType SeatType { get; set; }
	}
}
