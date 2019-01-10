namespace TravelDream.Services.DataServices.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Data.Models;

	public interface ITicketsService
	{
		Task<List<Ticket>> Add(int id, string st, int count, int discountId, User user);
	}
}
