namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Microsoft.EntityFrameworkCore;
	using TravelDream.Data.Models.Enums;
	using ViewModels.LocationModels;

	public class LocationsService : ILocationsService
	{
		private readonly IRepository<Location> _locationRepository;
		private readonly ICountriesService _countriesService;

		public LocationsService(IRepository<Location> locationRepository, ICountriesService countriesService)
		{
			this._locationRepository = locationRepository;
			this._countriesService = countriesService;
		}
		public bool IsExist(string name)
		{
			return this._locationRepository.All().ToList().Any(c => c.City == name);
		}

		public async Task<int> Add(InputLocationViewModel model)
		{
			var country = this._countriesService.GetById(model.CountryId);

			var location = new Location
			{
				City = model.Name,
				Country = country,
				HasAirport = model.HasAirport,
				HasTrainStation = model.HasTrainStation,
				HasPort = model.HasPort
			};
			await this._locationRepository.AddAsync(location);
			var result = await this._locationRepository.SaveChangesAsync();
			return result;
		}

		public IQueryable<LocationViewModel> GetAll()
		{
			var locations = this._locationRepository.All().Select(s => new LocationViewModel
			{
				Id = s.Id,
				City = s.City,
			});
			return locations;
		}

		public IQueryable<LocationViewModel> GetAllByCountry(int countryId, int transportType)
		{
			var country = this._countriesService.GetById(countryId);
			var transportationType = (TransportType)transportType;

			var locations = this._locationRepository
				.All()
				.Include(l => l.Country);

			if (transportationType == TransportType.Boat)
			{
				var filteredLocations = locations
					.Where(l => l.Country.Name == country.Name && l.HasPort)
					.Select(s => new LocationViewModel
					{
						Id = s.Id,
						City = s.City,
					});
				return filteredLocations;
			}
			else if (transportationType == TransportType.Train)
			{
				var filteredLocations = locations
					.Where(l => l.Country.Name == country.Name && l.HasTrainStation)
					.Select(s => new LocationViewModel
					{
						Id = s.Id,
						City = s.City,
					});
				return filteredLocations;
			}
			else if (transportationType == TransportType.Plane)
			{
				var filteredLocations = locations
					.Where(l => l.Country.Name == country.Name && l.HasAirport)
					.Select(s => new LocationViewModel
					{
						Id = s.Id,
						City = s.City,
					});
				return filteredLocations;
			}
			else
			{
				var filteredLocations = locations
					.Where(l => l.Country.Name == country.Name)
					.Select(s => new LocationViewModel
					{
						Id = s.Id,
						City = s.City,
					});
				return filteredLocations;
			}

		}
		public Location GetById(int id)
		{
			var location = this._locationRepository.All().FirstOrDefault(s => s.Id == id);
			return location;
		}
	}
}
