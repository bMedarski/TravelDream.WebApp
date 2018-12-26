namespace TravelDream.Services.DataServices.Contracts
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using ViewModels.DiscountModels;

	public interface IDiscountsService
	{
		Task<int> Add(InputDiscountViewModel model);
		IList<DiscountViewModel> All();
	}
}
