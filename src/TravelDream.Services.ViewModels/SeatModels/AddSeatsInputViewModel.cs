namespace TravelDream.Services.ViewModels.SeatModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;

	public class AddSeatsInputViewModel
	{

		[Display(Name = "Seats Count")]
		public int SeatCount { get; set; }

		[Display(Name = "Type of  seat")]
		public SeatType SeatType { get; set; }

		[Display(Name = "Transport Designation")]
		public int TransportId { get; set; }

		[Display(Name = "Price")]
		public decimal Price { get; set; }
	}
}
