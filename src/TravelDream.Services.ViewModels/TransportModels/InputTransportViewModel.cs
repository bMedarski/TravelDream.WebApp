namespace TravelDream.Services.ViewModels.TransportModels
{
	using Data.Models;
	using Data.Models.Enums;

	public class InputTransportViewModel
	{
		public TransportType TransportType { get; set; }
		public Company Company { get; set; }
		public int SeatsAvailable { get; set; }
	}
}
