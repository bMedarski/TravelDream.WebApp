namespace TravelDream.Services.ViewModels.CountryModels
{
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Mvc;
	using Utilities.Constants;

	public class InputCountryViewModel
	{
		[Remote(action: "IsExist", controller: "Countries",ErrorMessage =InputModelsConstants.CountryAlreadyExistError)]
		[Required(ErrorMessage = InputModelsConstants.RequiredErrorMessage)]
		[MinLength(InputModelsConstants.CountryNameLength,ErrorMessage = InputModelsConstants.CountryNameLengthError)]
		public string Name { get; set; }
	}
}
