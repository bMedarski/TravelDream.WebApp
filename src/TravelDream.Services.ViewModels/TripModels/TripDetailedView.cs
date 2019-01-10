namespace TravelDream.Services.ViewModels.TripModels
{
	using System.Collections.Generic;
	using Data.Models.Enums;
	using DiscountModels;
	using Microsoft.AspNetCore.Mvc.Rendering;
	using SeatModels;

	public class TripDetailedView
	{
		public TripDetailedView()
		{
			this.Seats = new List<DetailedSeatViewModel>();
			this.SeatTypes = new List<SeatTypesViewModel>();
			this.Discounts = new List<DiscountViewModel>();
		}
		public int Id { get; set; }
		public string DepartureCity { get; set; }
		public string DepartureCountry { get; set; }
		public string DestinationCity { get; set; }	
		public string DestinationCountry { get; set; }	
		public string DepartureTime { get; set; }	
		public string ArrivalTime { get; set; }
		public string TransportType { get; set; }
		public string TransportDesignationNumber { get; set; }
		public string CompanyName { get; set; }
		public IList<DetailedSeatViewModel> Seats { get; set; }
		public IList<SeatTypesViewModel> SeatTypes { get; set; }
		public IList<DiscountViewModel> Discounts { get; set; }
	}
}
