using TravelDream.Services.ViewModels.CompanyModels;

namespace TravelDream.Services.DataServices.Contracts
{
	using System.Threading.Tasks;

	public interface ICompaniesService
	{
		Task<int> Add(InputCompanyViewModel model);
	}
}
