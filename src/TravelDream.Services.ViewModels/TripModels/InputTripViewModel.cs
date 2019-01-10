namespace TravelDream.Services.ViewModels.TripModels
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;
	using Utilities.ValidationAttributes;

	public class InputTripViewModel
	{
		[Display(Name = "Type of transportation")]
		public TransportType TransportType { get; set; }

		[Display(Name = "Departure country")]
		public int DepartureCountryId { get; set; }

		[Display(Name = "Departure location")]
		public int DepartureLocationId { get; set; }

		[Display(Name = "Destination country")]
		public int DestinationCountryId { get; set; }

		[UnlikeValidation("DepartureLocationId",ErrorMessage = "Second location must be different than the first")]
		[Display(Name = "Destination location")]
		public int DestinationLocationId { get; set; }

		[Display(Name="Transport")]
		public int TransportId { get; set; }

		[Display(Name = "Departure Time")]
		public DateTime DepartureTime { get; set; }

		[Display(Name = "Arrival Time")]
		[DateGreaterThan("DepartureTime")]
		public DateTime ArrivalTime { get; set; }


	}
}
