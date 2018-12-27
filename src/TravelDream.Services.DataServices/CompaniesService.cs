namespace TravelDream.Services.DataServices
{
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using ViewModels.CompanyModels;

	public class CompaniesService : ICompaniesService
	{
		private readonly IRepository<Company> _companiesRepository;
		private readonly ICountriesService _countriesService;

		public CompaniesService(IRepository<Company> companiesRepository, ICountriesService countriesService)
		{
			this._companiesRepository = companiesRepository;
			this._countriesService = countriesService;
		}

		public async Task<int> Add(InputCompanyViewModel model)
		{
			var country = this._countriesService.GetById(model.CountryId);
			var company = new Company
			{
				Name = model.Name,
				Address = model.Address,
				PhoneNumber = model.PhoneNumber,
				Country = country,
				Email = model.Email
			};
			await this._companiesRepository.AddAsync(company);
			await this._companiesRepository.SaveChangesAsync();

			return company.Id;
		}
	}
}
