namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using ViewModels.TripModels;

	public class TripsService:ITripsService
	{
		private readonly IRepository<Trip> _tripsRepository;
		private readonly ICitiesService _citiesService;
		private readonly ITransportsService _transportsService;

		public TripsService(IRepository<Trip> tripsRepository,ICitiesService citiesService,ITransportsService transportsService)
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
			var location = new Trip
			{
				Departure = departureLocation,
				Destination = destinationLocation,
				DepartureTime = model.DepartureTime,
				ArrivalTime = model.ArrivalTime,
				Transport = transport
			};
			await this._tripsRepository.AddAsync(location);
			var result = await this._tripsRepository.SaveChangesAsync();
			return result;
		}

		public IQueryable<TripViewModel> GetAll()
		{
			var locations = this._tripsRepository.All().Select(s => new TripViewModel()
			{
				Id = s.Id,
				Destination = s.Destination.Name,
				Departure = s.Departure.Name,
			});
			return locations;
		}
		public Trip GetById(int id)
		{
			var trip = this._tripsRepository.All().FirstOrDefault(s => s.Id == id);
			return trip;
		}
	}
}
