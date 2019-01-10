namespace TravelDream.Services.ViewModels.TransportModels
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models.Enums;
	using Utilities.Constants;

	public class InputTransportViewModel
	{
		[Display(Name = InputModelsConstants.TransportTypeDisplayName)]
		public TransportType TransportType { get; set; }

		[Display(Name = InputModelsConstants.CompanyNameDisplayName)]
		public int CompanyId { get; set; }

		[Display(Name = InputModelsConstants.TransportDesignationDisplayName)]
		[RegularExpression(InputModelsConstants.DesignationNumberRegex)]
		public string Number { get; set; }
	}
}
