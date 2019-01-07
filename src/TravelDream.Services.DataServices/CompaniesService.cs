namespace TravelDream.Services.DataServices
{
	using System.Linq;
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
		public bool IsExist(string name)
		{
			return this._companiesRepository.All().ToList().Any(c=>c.Name==name);
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
		public IQueryable<CompanyViewModel> GetAll()
		{
			var companies = this._companiesRepository.All().Select(s => new CompanyViewModel
			{
				Id = s.Id,
				Name = s.Name
			});
			return companies;
		}
		public Company GetById(int id)
		{
			var company = this._companiesRepository.All().FirstOrDefault(s => s.Id == id);
			return company;
		}
	}
}
