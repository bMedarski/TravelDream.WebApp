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
	using Microsoft.EntityFrameworkCore;
	using ViewModels.TransportModels;

	public class TransportsService : ITransportsService
	{
		private readonly IRepository<Transport> _transportRepository;
		private readonly ICompaniesService _companiesService;
		private readonly IRepository<Trip> _tripsService;

		public TransportsService(IRepository<Transport> transportRepository, ICompaniesService companiesService, IRepository<Trip> tripsService)
		{
			this._transportRepository = transportRepository;
			this._companiesService = companiesService;
			this._tripsService = tripsService;
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
			var transports = this._transportRepository.All().Include(t => t.Company).Select(s => new TransportViewModel()
			{
				Id = s.Id,
				DesignationNumber = s.DesignationNumber,
				CompanyName = s.Company.Name
			});
			return transports;
		}

		public Transport GetById(int id)
		{
			var transport = this._transportRepository.All()
				.FirstOrDefault(t => t.Id == id);
			return transport;
		}

		public IQueryable<TransportViewModel> GetAllByType(int transportType)
		{
			var transportationType = (TransportType)transportType;
			var transports = this._transportRepository.All()
				.Include(t => t.Company)
				.Where(t => t.TransportType == transportationType && t.LastSeatNumber > 0)
				.Select(s => new TransportViewModel()
				{
					Id = s.Id,
					DesignationNumber = s.DesignationNumber,
					CompanyName = s.Company.Name
				});
			return transports;
		}
		public IList<TransportViewModel> GetAllByTypeAvailable(int transportType)
		{
			var transportsAvailable = new List<TransportViewModel>();
			var transportsTaken =
				this._tripsService.All().Include(t => t.Transport).Select(t => t.Transport).ToList();

			var transportationType = (TransportType)transportType;


			var transports = this._transportRepository.All()
				.Include(t => t.Company)
				.Where(t => t.TransportType == transportationType && t.LastSeatNumber > 0)
				.Select(s => new TransportViewModel()
				{
					Id = s.Id,
					DesignationNumber = s.DesignationNumber,
					CompanyName = s.Company.Name
				}).ToList();
			foreach (var transportViewModel in transports)
			{
				if (!(transportsTaken.Any(t => t.Id == transportViewModel.Id)))
				{
					transportsAvailable.Add(transportViewModel);
				}
			}
			return transportsAvailable;
		}

		public bool IsTransportOfCorrectType(int transportId, TransportType type)
		{
			var transport = this._transportRepository.All().FirstOrDefault(t => t.Id == transportId);
			if (transport != null && transport.TransportType == type)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
