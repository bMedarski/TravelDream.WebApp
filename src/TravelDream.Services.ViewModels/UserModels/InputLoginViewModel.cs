namespace TravelDream.Services.ViewModels.UserModels
{
	using System.ComponentModel.DataAnnotations;
	using Utilities.Constants;

	public class InputLoginViewModel
	{
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.UsernameMinimumLength,
			ErrorMessage = InputModelsConstants.UsernameLengthErrorMessage)]
		[RegularExpression(InputModelsConstants.UsernameRegularExpressionFormat,
			ErrorMessage = InputModelsConstants.UsernameInvalidErrorMessage)]
		public string Username { get; set; }

		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[DataType(DataType.Password)]
		[MinLength(InputModelsConstants.PasswordMinimumLength,
			ErrorMessage = InputModelsConstants.PasswordLengthErrorMessage)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
