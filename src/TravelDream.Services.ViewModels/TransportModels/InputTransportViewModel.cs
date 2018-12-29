namespace TravelDream.Services.ViewModels.TransportModels
{
	using Data.Models.Enums;

	public class InputTransportViewModel
	{
		public TransportType TransportType { get; set; }
		public int CompanyId { get; set; }
		public int Number { get; set; }
	}
}
