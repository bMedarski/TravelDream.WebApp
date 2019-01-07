namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Data.Models.Enums;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.CityModels;

	public class CitiesService : ICitiesService
	{
		private readonly IRepository<City> _cityRepository;
		private readonly ICountriesService _countriesService;

		public CitiesService(IRepository<City> cityRepository, ICountriesService countriesService)
		{
			this._cityRepository = cityRepository;
			this._countriesService = countriesService;
		}
		public bool IsExist(string name)
		{
			return this._cityRepository.All().ToList().Any(c => c.Name == name);
		}

		public async Task<int> Add(InputCityViewModel model)
		{
			var country = this._countriesService.GetById(model.CountryId);

			var city = new City
			{
				Name = model.Name,
				Country = country,
				HasAirport = model.HasAirport,
				HasTrainStation = model.HasTrainStation,
				HasPort = model.HasPort
			};
			await this._cityRepository.AddAsync(city);
			var result = await this._cityRepository.SaveChangesAsync();
			return result;
		}

		public IQueryable<CityViewModel> GetAll()
		{
			var cities = this._cityRepository.All().Select(s => new CityViewModel
			{
				Id = s.Id,
				City = s.Name,
			});
			return cities;
		}

		public IQueryable<CityViewModel> GetAllByCountry(int countryId, int transportType)
		{
			var country = this._countriesService.GetById(countryId);
			var transportationType = (TransportType)transportType;

			var cities = this._cityRepository
				.All()
				.Include(l => l.Country);

			if (transportationType == TransportType.Boat)
			{
				var filteredCities = cities
					.Where(l => l.Country.Name == country.Name && l.HasPort)
					.Select(s => new CityViewModel
					{
						Id = s.Id,
						City = s.Name,
					});
				return filteredCities;
			}
			else if (transportationType == TransportType.Train)
			{
				var filteredCities = cities
					.Where(l => l.Country.Name == country.Name && l.HasTrainStation)
					.Select(s => new CityViewModel
					{
						Id = s.Id,
						City = s.Name,
					});
				return filteredCities;
			}
			else if (transportationType == TransportType.Plane)
			{
				var filteredCities = cities
					.Where(l => l.Country.Name == country.Name && l.HasAirport)
					.Select(s => new CityViewModel
					{
						Id = s.Id,
						City = s.Name,
					});
				return filteredCities;
			}
			else
			{
				var filteredCities = cities
					.Where(l => l.Country.Name == country.Name)
					.Select(s => new CityViewModel
					{
						Id = s.Id,
						City = s.Name,
					});
				return filteredCities;
			}

		}
		public City GetById(int id)
		{
			var city = this._cityRepository.All().FirstOrDefault(s => s.Id == id);
			return city;
		}
	}
}
