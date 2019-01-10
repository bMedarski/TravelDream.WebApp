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
		public const string UserAlreadyExistErrorMessage = "User already exist";
		public const string WrongUsernameOrPasswordErrorMessage = "Wrong username or password!";

		public const string UsernameRegularExpressionFormat = "[a-zA-Z0-9-*_~.]+";
		public const string EmailRegularExpressionFormat = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
		                                                   @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
		                                                   @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

		public const string ImageUrlRegularExpressionFormat = "(http(s?):)([/|.|\\w|\\s|-])*\\.(?:jpg|gif|png)";
		public const string DateFormatTime = "yyyy/MM/dd hh:mm tt";
		public const string DateFormat = "dd/MMMM hh:mm ";

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

		public const string TransportTypeDisplayName = "Type of transportation";
		public const string DepartureCountryDisplayName = "Departure Country";
		public const string DepartureCityDisplayName = "Departure City";
		public const string DestinationCountryDisplayName = "Destination Country";
		public const string DestinationCityDisplayName = "Destination City";
		public const string TransportDisplayName = "Transport";
		public const string DepartureTimeDisplayName = "Departure Time";
		public const string ArrivalTimeDisplayName = "Arrival Time";
		public const string CountryAlreadyExistError = "Country already exists";

		public const string FutureDateValidationError = "Starting date must not be in the past";
		public const string DepartureDateBeforeArrivalDateError = "Departure date must be before arrival date";

		public const string CityInCountryError = "City must be in the Country";
		public const string TransportNotCorrectType = "Transport are not from correct Transport Type";
		public const string CityDoesNotSupportsType = "City does not supports transportaion type";

		public const int CompanyNameLength = 3;
		public const string CompanyNameLengthError = "Length must be more than 3";

		public const int AddressNameLength = 5;
		public const string AddressNameLengthError = "Length must be more than 5";

		public const int CountryNameLength = 3;
		public const string CountryNameLengthError = "Length must be more than 3";

		public const string SeatCountDisplayName = "Seat Count";
		public const string TypeSeatDisplayName = "Type of Seat";
		public const string TransportDesignationDisplayName = "Transport Designation";

		public const int MinPrice = 1;
		public const int MaxPrice = 9999;

		public const int MinSeatCount = 1;
		public const int MaxSeatCount = 10;

		public const string CompanyNameDisplayName = "Company name";

		public const string DesignationNumberRegex = "^[a-zA-Z0-9]{12}$";
	}
}
