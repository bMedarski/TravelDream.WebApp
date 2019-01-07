namespace TravelDream.Services.ViewModels.CityModels
{
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Mvc;

	public class InputCityViewModel
	{
		//TODO Validation msg to constants
		[Remote(action: "IsExist", controller: "Cities",ErrorMessage ="City already exist!")]
		public string Name { get; set; }

		[Display(Name = "Country")]
		public int CountryId { get; set; }
		
		[Display(Name = "Has Airport")]
		public bool HasAirport { get; set; }

		[Display(Name = "Has Seaport")]
		public bool HasPort { get; set; }

		[Display(Name = "Has Train Station")]
		public bool HasTrainStation { get; set; }
	}
}
