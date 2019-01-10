namespace TravelDream.Services.DataServices
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Data.Models.Enums;

	public class TicketsService : ITicketsService
	{
		private readonly IRepository<Ticket> _ticketRepository;
		private readonly IDiscountsService _discountsService;
		private readonly ITripsService _tripsService;

		public TicketsService(IRepository<Ticket> ticketRepository, IDiscountsService discountsService, ITripsService tripsService)
		{
			this._ticketRepository = ticketRepository;
			this._discountsService = discountsService;
			this._tripsService = tripsService;
		}
		public async Task<List<Ticket>> Add(int id,string st,int count , int discount, User user)
		{
			var discountEntity = this._discountsService.GetById(discount);
			SeatType seatType = (SeatType)Enum.Parse(typeof(SeatType), st);
			var tickets = new List<Ticket>();
			for (int i = 0; i < count; i++)
			{
				var seat = this._tripsService.GetById(id).Transport.Seats.FirstOrDefault(s => s.Type == seatType);
				var ticket = new Ticket
				{
					Price = discountEntity.Percent*seat.Price,
					Seat = seat,
					Buyer = user
				};
				await this._ticketRepository.AddAsync(ticket);
				tickets.Add(ticket);
				user.Tickets.Add(ticket);

				this._tripsService.DropSeat(id, seat,count);
			}
			await this._ticketRepository.SaveChangesAsync();
			return tickets;
		}
	}
}
