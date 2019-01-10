namespace TravelDream.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Models;
	using Data.Models.Enums;
	using ViewModels.CityModels;

	public interface ICitiesService
	{
		bool IsExist(string name);
		Task<int> Add(InputCityViewModel model);
		IQueryable<CityViewModel> GetAll();
		IQueryable<CityViewModel> GetAllByCountry(int countryId, int transportType);
		City GetById(int id);
		bool IsCityInCountry(int cityId, int countryId);
		bool IsCityForTransportType(int cityId, TransportType type);
	}
}
