namespace TravelDream.Services.DataServices.Contracts
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Models;
	using ViewModels.TransportModels;

	public interface ITransportsService
	{
		Task<int> Add(InputTransportViewModel model);
		IQueryable<TransportViewModel> GetAll();
		Transport GetById(int id);
		IQueryable<TransportViewModel> GetAllByType(int transportType);
		IList<TransportViewModel> GetAllByTypeAvailable(int transportType);
	}
}
