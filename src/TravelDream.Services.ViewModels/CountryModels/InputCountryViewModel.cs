namespace TravelDream.Services.ViewModels.CountryModels
{
	using Microsoft.AspNetCore.Mvc;

	public class InputCountryViewModel
	{
		[Remote(action: "IsExist", controller: "Countries",ErrorMessage ="Country already exist!")]
		public string Name { get; set; }
	}
}
