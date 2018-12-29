namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using ViewModels.TransportModels;

	public class TransportsService : ITransportsService
	{
		private readonly IRepository<Transport> _transportRepository;
		private readonly ICompaniesService _companiesService;

		public TransportsService(IRepository<Transport> transportRepository,ICompaniesService companiesService)
		{
			this._transportRepository = transportRepository;
			this._companiesService = companiesService;
		}
		public async Task<int> Add(InputTransportViewModel model)
		{
			var company = this._companiesService.GetById(model.CompanyId);
			var transport = new Transport
			{
				LastSeatNumber = 0,
				Company = company,
				TransportType = model.TransportType,
				DesignationNumber = model.Number,
			};

			await this._transportRepository.AddAsync(transport);
			await this._transportRepository.SaveChangesAsync();

			return transport.Id;
		}

		public IQueryable<TransportViewModel> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Transport GetById(int id)
		{
			var transport = this._transportRepository.All().FirstOrDefault(t => t.Id == id);
			return transport;
		}
	}
}
