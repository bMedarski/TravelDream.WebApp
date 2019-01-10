namespace TravelDream.Services.DataServices
{
	using System;
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Data.Models.Enums;
	using Microsoft.EntityFrameworkCore;
	using Utilities.Constants;
	using ViewModels.DiscountModels;
	using ViewModels.SeatModels;
	using ViewModels.TripModels;

	public class TripsService : ITripsService
	{
		private readonly IRepository<Trip> _tripsRepository;
		private readonly ICitiesService _citiesService;
		private readonly ITransportsService _transportsService;
		private readonly IDiscountsService _discountsService;

		public TripsService(IRepository<Trip> tripsRepository, ICitiesService citiesService, ITransportsService transportsService, IDiscountsService discountsService)
		{
			this._tripsRepository = tripsRepository;
			this._citiesService = citiesService;
			this._transportsService = transportsService;
			this._discountsService = discountsService;
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
			var trip = this._tripsRepository.All()
				.Include(t=>t.Transport)
				.ThenInclude(s=>s.Seats)
				.Include(t=>t.Transport)
				.ThenInclude(s=>s.SeatsTaken)
				.FirstOrDefault(s => s.Id == id);
			return trip;
		}

		public void DropSeat(int id, Seat seat,int count)
		{
			var transport = this._tripsRepository.All().FirstOrDefault(t => t.Id == id)?.Transport;
			if (transport != null)
			{
				transport.Seats.Remove(seat);
				transport.SeatsTaken.Add(seat);
			}

		}
		public bool HasEnoughTickets(int id, int ticketsCount, string ticketsType)
		{
			SeatType seatType = (SeatType)Enum.Parse(typeof(SeatType), ticketsType);
			var seats = this._tripsRepository.All()
				.Include(t => t.Transport)
				.Where(t => t.Id == id).Select(t => t.Transport.Seats).ToList();
			foreach (var seat in seats)
			{
				var available = seat.Count(s => s.Type == seatType);
				if (available > ticketsCount)
				{
					return true;
				}
			}
			return false;
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
					TransportDesignationNumber = t.Transport.DesignationNumber,
					Seats = t.Transport.Seats
						.Select(s => new DetailedSeatViewModel
						{
							Id = s.Id,
							Number = s.Number,
							Price = s.Price,
							Type = s.Type.ToString()
						}).ToList()
				}).FirstOrDefault();

			if (trip != null)
			{
				var seatTypes = trip.Seats.Select(t => t.Type).Distinct();
				foreach (var seatType in seatTypes)
				{
					var availableTickets = trip.Seats.Count(s => s.Type == seatType);
					var selectedSeatTypeListItem = new SeatTypesViewModel
					{
						SeatType = seatType,
						SeatCount = availableTickets,
						SeatPrice = trip.Seats.Where(s => s.Type == seatType).Select(s => s.Price).FirstOrDefault()
					};
					trip.SeatTypes.Add(selectedSeatTypeListItem);
				}
				trip.Discounts = this._discountsService.All().Select(d => new DiscountViewModel
				{
					Id = d.Id,
					Name = d.Name,
					Percent = d.Percent
				}).ToList();
			}

			return trip;
		}
	}
}
