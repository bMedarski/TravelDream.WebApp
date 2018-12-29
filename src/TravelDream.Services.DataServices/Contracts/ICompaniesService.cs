using TravelDream.Services.ViewModels.CompanyModels;

namespace TravelDream.Services.DataServices.Contracts
{
	using System.Linq;
	using System.Threading.Tasks;
	using Data.Models;

	public interface ICompaniesService
	{
		Task<int> Add(InputCompanyViewModel model);
		bool IsExist(string name);
		IQueryable<CompanyViewModel> GetAll();
		Company GetById(int id);
	}
}
