namespace TravelDream.Services.Utilities.Constants
{
	public class InputModelsConstants
	{
		public const string RequiredErrorMessage = "The field is Required!";
		public const string ComparePasswordErrorMessage = "Password and confirm password must be the same";

		public const string UsernameInvalidErrorMessage = "Username is not valid";
		public const string EmailInvalidErrorMessage = "Email is not valid";
		public const string DateInvalidErrorMessage = "Date is not valid";
		public const string ImageUrlInvalidErrorMessage = "Image URL is not valid";

		public const string UsernameRegularExpressionFormat = "[a-zA-Z0-9-*_~.]+";
		public const string EmailRegularExpressionFormat = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
		                                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
		                                                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

		public const string ImageUrlRegularExpressionFormat = "(http(s?):)([/|.|\\w|\\s|-])*\\.(?:jpg|gif|png)";
		public const string DateFormat = "{yyyy/MM/dd hh:mm tt}";

		public const int UsernameMinimumLength = 3;
		public const string UsernameLengthErrorMessage = "Length must be more then 3";
		public const int PasswordMinimumLength = 5;
		public const string PasswordLengthErrorMessage = "Length must be more then 5";

		public const string ChildDiscountText = "Child";
		public const decimal ChildDiscountPercent = (decimal) 0.8;

		public const string SeniorDiscountText = "Senior";
		public const decimal SeniorDiscountPercent = (decimal) 0.9;

		public const string StudentDiscountText = "Student";
		public const decimal StudentDiscountPercent = (decimal) 0.7;

		public const string NormalDiscountText = "Normal";
		public const decimal NormalDiscountPercent = (decimal) 1;




	}
}
