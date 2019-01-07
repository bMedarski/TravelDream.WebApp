namespace TravelDream.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Models;
	using ViewModels.LocationModels;

	public interface ILocationsService
	{
		bool IsExist(string name);
		Task<int> Add(InputLocationViewModel model);
		IQueryable<LocationViewModel> GetAll();
		IQueryable<LocationViewModel> GetAllByCountry(int countryId, int transportType);
		Location GetById(int id);
	}
}
