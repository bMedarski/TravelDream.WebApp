namespace TravelDream.Services.ViewModels.SeatModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;
	using Utilities.Constants;

	public class AddSeatsInputViewModel
	{

		[Display(Name = InputModelsConstants.SeatCountDisplayName)]
		[Range(InputModelsConstants.MinSeatCount,InputModelsConstants.MaxSeatCount)]
		public int SeatCount { get; set; }

		[Display(Name = InputModelsConstants.TypeSeatDisplayName)]
		public SeatType SeatType { get; set; }

		[Display(Name = InputModelsConstants.TransportDesignationDisplayName)]
		public int TransportId { get; set; }

		[Range(InputModelsConstants.MinPrice,InputModelsConstants.MaxPrice)]
		public decimal Price { get; set; }
	}
}
