namespace TravelDream.Services.ViewModels.CompanyModels
{
	using Data.Common;

	public class InputCompanyViewModel
	{
		//TODO Validation
		public string Name { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public int PhoneNumber { get; set; }

		public int CountryId { get; set; }
	}
}
