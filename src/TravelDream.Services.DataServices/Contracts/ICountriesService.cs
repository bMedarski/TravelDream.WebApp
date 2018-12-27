namespace TravelDream.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using ViewModels.CountryModels;

	public interface ICountriesService
	{
		bool IsExist(string name);
		Task<int> Add(InputCountryViewModel model);
	}
}
