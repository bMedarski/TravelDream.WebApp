namespace TravelDream.Services.ViewModels.CompanyModels
{
	using System.ComponentModel.DataAnnotations;
	using Utilities.Constants;

	public class InputCompanyViewModel
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.CompanyNameLength,ErrorMessage = InputModelsConstants.CompanyNameLengthError)]
		public string Name { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[RegularExpression(InputModelsConstants.EmailRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.EmailInvalidErrorMessage)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.AddressNameLength,ErrorMessage = InputModelsConstants.AddressNameLengthError)]
		public string Address { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public int PhoneNumber { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		public int CountryId { get; set; }
	}
}
