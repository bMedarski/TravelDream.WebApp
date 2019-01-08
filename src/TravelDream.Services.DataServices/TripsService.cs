namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Microsoft.EntityFrameworkCore;
	using Utilities.Constants;
	using ViewModels.TripModels;

	public class TripsService : ITripsService
	{
		private readonly IRepository<Trip> _tripsRepository;
		private readonly ICitiesService _citiesService;
		private readonly ITransportsService _transportsService;

		public TripsService(IRepository<Trip> tripsRepository, ICitiesService citiesService, ITransportsService transportsService)
		{
			this._tripsRepository = tripsRepository;
			this._citiesService = citiesService;
			this._transportsService = transportsService;
		}
		public async Task<int> Add(InputTripViewModel model)
		{
			var destinationLocation = this._citiesService.GetById(model.DestinationLocationId);
			var departureLocation = this._citiesService.GetById(model.DepartureLocationId);
			var transport = this._transportsService.GetById(model.TransportId);
			var trip = new Trip
			{
				Departure = departureLocation,
				Destination = destinationLocation,
				DepartureTime = model.DepartureTime,
				ArrivalTime = model.ArrivalTime,
				Transport = transport
			};
			await this._tripsRepository.AddAsync(trip);
			var result = await this._tripsRepository.SaveChangesAsync();
			return result;
		}

		public IQueryable<TripViewModel> GetAll()
		{
			var trips = this._tripsRepository.All()
				.Include(t => t.Departure)
				.Include(t => t.Destination)
				.Select(s => new TripViewModel()
				{
					Id = s.Id,
					Destination = s.Destination.Name,
					Departure = s.Departure.Name,
					DepartureTime = s.DepartureTime.ToString(InputModelsConstants.DateFormat),
					ArrivalTime = s.ArrivalTime.ToString(InputModelsConstants.DateFormat),
				});
			return trips;
		}
		public Trip GetById(int id)
		{
			var trip = this._tripsRepository.All().FirstOrDefault(s => s.Id == id);
			return trip;
		}

		public TripDetailedView Details(int id)
		{
			var trip = this._tripsRepository.All()
				.Where(t => t.Id == id)
				.Include(t => t.Transport)
				.ThenInclude(t => t.Company)
				.Include(t => t.Departure)
				.ThenInclude(t => t.Country)
				.Include(t => t.Destination)
				.ThenInclude(t => t.Country)
				.Select(t => new TripDetailedView
				{
					Id = t.Id,
					DepartureTime = t.DepartureTime.ToString(InputModelsConstants.DateFormat),
					DepartureCity = t.Departure.Name,
					DepartureCountry = t.Departure.Country.Name,
					ArrivalTime = t.ArrivalTime.ToString(InputModelsConstants.DateFormat),
					DestinationCity = t.Destination.Name,
					DestinationCountry = t.Destination.Country.Name,
					TransportType = t.Transport.TransportType.ToString(),
					CompanyName = t.Transport.Company.Name,
					TransportDesignationNumber = t.Transport.DesignationNumber
				}).FirstOrDefault();

			return trip;
		}
	}
}
