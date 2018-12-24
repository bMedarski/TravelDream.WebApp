namespace TravelDream.Services.ViewModels.UserModels
{
	using System.ComponentModel.DataAnnotations;
	using Utilities.Constants;

	public class InputRegisterViewModel
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.UsernameMinimumLength,ErrorMessage = InputModelsConstants.UsernameLengthErrorMessage)]
		[RegularExpression(InputModelsConstants.UsernameRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.UsernameInvalidErrorMessage)]
		public string Username { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[RegularExpression(InputModelsConstants.EmailRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.EmailInvalidErrorMessage)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[DataType(DataType.Password)]
		[MinLength(InputModelsConstants.PasswordMinimumLength,
			ErrorMessage = InputModelsConstants.PasswordLengthErrorMessage)]
		public string Password { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[Display(Name = "Confirm password")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage = InputModelsConstants.ComparePasswordErrorMessage)]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
