namespace TravelDream.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Common;
	using ViewModels.CountryModels;

	public interface ICountriesService
	{
		bool IsExist(string name);
		Task<int> Add(InputCountryViewModel model);
		IQueryable<CountryViewModel> GetAll();
		Country GetById(int id);
	}
}
