namespace TravelDream.Services.DataServices.Contracts
{
	using System.Threading.Tasks;
	using ViewModels.SeatModels;

	public interface ISeatsService
	{
		Task<int> AddSeats(AddSeatsInputViewModel model);
	}
}
