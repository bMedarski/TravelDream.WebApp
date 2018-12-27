namespace TravelDream.Services.DataServices
{
	using Contracts;
	using Data.Common;
	using Data.Models;

	public class CompaniesService : ICompaniesService
	{
		private readonly IRepository<Company> _companiesRepository;

		public CompaniesService(IRepository<Company> companiesRepository)
		{
			this._companiesRepository = companiesRepository;
		}



	}
}
