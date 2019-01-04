namespace TravelDream.Services.DataServices
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using ViewModels.SeatModels;

	public class SeatsService:ISeatsService
	{
		private readonly IRepository<Seat> _seatsRepository;
		private readonly ITransportsService _transportsService;

		public SeatsService(IRepository<Seat> seatsRepository, ITransportsService transportsService)
		{
			this._seatsRepository = seatsRepository;
			this._transportsService = transportsService;
		}

		public async Task<int> AddSeats(AddSeatsInputViewModel model)
		{
			var transport = this._transportsService.GetById(model.TransportId);
			var currentSeatNumber = transport.LastSeatNumber;
			var seats = new List<Seat>();

			for (int i = 0; i < model.SeatCount; i++)
			{
				var seat = new Seat
				{
					Type = model.SeatType,
					Price = model.Price,
					Number = ++currentSeatNumber,
				};
				seats.Add(seat);
				transport.LastSeatNumber++;
				transport.Seats.Add(seat);
			}
			
			await this._seatsRepository.AddRangeAsync(seats);
			await this._seatsRepository.SaveChangesAsync();
			return 0;
		}
	}
}
