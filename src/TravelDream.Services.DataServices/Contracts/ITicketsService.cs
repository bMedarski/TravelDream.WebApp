namespace TravelDream.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using ViewModels.TicketModels;

	public interface ITicketsService
	{
		Task<int> Add(InputTicketViewModel model);
	}
}
