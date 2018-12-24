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

		public const int CompetitionNameMinimumLength = 3;
		public const string CompetitionNameLengthErrorMessage = "Length must be more then 3";

		public const int SeasonNameMinimumLength = 3;
		public const string SeasonNameLengthErrorMessage = "Length must be more then 3";

		public const int TeamNameMinimumLength = 3;
		public const string TeamNameLengthErrorMessage = "Length must be more then 3";
		public const string TeamUrlDisplayName = "Team Logo URL";

		public const int PlayerFirstNameMinimumLength = 3;
		public const string PlayerFirstNameLengthErrorMessage = "Length must be more then 3";
		public const int PlayerSecondNameMinimumLength = 5;
		public const string PlayerSecondNameLengthErrorMessage = "Length must be more then 5";
		public const string PlayerUrlDisplayName = "Player Picture URL";
	}
}
