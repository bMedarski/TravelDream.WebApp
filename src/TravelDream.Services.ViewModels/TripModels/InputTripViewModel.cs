namespace TravelDream.Services.ViewModels.TripModels
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;
	using Utilities.Constants;
	using Utilities.ValidationAttributes;

	public class InputTripViewModel
	{
		[Display(Name = InputModelsConstants.TransportTypeDisplayName)]
		public TransportType TransportType { get; set; }

		[Display(Name = InputModelsConstants.DepartureCountryDisplayName)]
		public int DepartureCountryId { get; set; }

		[Display(Name = InputModelsConstants.DepartureCityDisplayName)]
		public int DepartureLocationId { get; set; }

		[Display(Name = InputModelsConstants.DestinationCountryDisplayName)]
		public int DestinationCountryId { get; set; }

		[Display(Name = InputModelsConstants.DestinationCityDisplayName)]
		public int DestinationLocationId { get; set; }

		[Display(Name = InputModelsConstants.TransportDisplayName)]
		public int TransportId { get; set; }

		[Display(Name = InputModelsConstants.DepartureTimeDisplayName)]
		[FutureDateValidation(ErrorMessage = InputModelsConstants.FutureDateValidationError)]
		[DataType(DataType.DateTime)]
		public DateTime DepartureTime { get; set; }

		[Display(Name = InputModelsConstants.ArrivalTimeDisplayName)]
		[DateGreaterThan("DepartureTime")]
		[DataType(DataType.DateTime)]
		public DateTime ArrivalTime { get; set; }
	}
}
