namespace TravelDream.Services.ViewModels.TripModels
{
	public class TripDetailedView
	{
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
	}
}
