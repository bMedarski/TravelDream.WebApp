namespace TravelDream.Services.ViewModels.LocationModels
{
	using Microsoft.AspNetCore.Mvc;

	public class InputLocationViewModel
	{
		//TODO Validation msg to constants
		[Remote(action: "IsExist", controller: "Locations",ErrorMessage ="Location already exist!")]
		public string Name { get; set; }

		public int CountryId { get; set; }
		
		public bool HasAirport { get; set; }

		public bool HasPort { get; set; }

		public bool HasTrainStation { get; set; }
	}
}
