namespace TravelDream.Services.DataServices
{
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using ViewModels.CountryModels;

	public class CountriesService:ICountriesService
	{
		private readonly IRepository<Country> _countryRepository;

		public CountriesService(IRepository<Country> countryRepository)
		{
			this._countryRepository = countryRepository;
		}

		public bool IsExist(string name)
		{
			return this._countryRepository.All().ToList().Any(c=>c.Name==name);
		}

		public async Task<int> Add(InputCountryViewModel model)
		{
			var country = new Country
			{
				Name = model.Name,
			};
			await this._countryRepository.AddAsync(country);
			await this._countryRepository.SaveChangesAsync();
			return country.Id;
		}

		public IQueryable<CountryViewModel> GetAll()
		{
			var countries = this._countryRepository.All().Select(s => new CountryViewModel
			{
				Id = s.Id,
				Name = s.Name
			});
			return countries;
		}

		public Country GetById(int id)
		{
			var country = this._countryRepository.All().FirstOrDefault(s => s.Id == id);
			return country;
		}
	}
}
