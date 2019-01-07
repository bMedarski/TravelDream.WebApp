namespace TravelDream.Services.ViewModels.TransportModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;

	public class InputTransportViewModel
	{
		[Display(Name = "Transport type")]
		public TransportType TransportType { get; set; }

		[Display(Name = "Company name")]
		public int CompanyId { get; set; }

		[Display(Name = "Designation number")]
		public string Number { get; set; }
	}
}
