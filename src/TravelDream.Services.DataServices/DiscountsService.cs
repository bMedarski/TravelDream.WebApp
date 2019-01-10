namespace TravelDream.Services.DataServices
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Contracts;
	using Data.Common;
	using Data.Models;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.DiscountModels;

	public class DiscountsService:IDiscountsService
	{
		private readonly IRepository<Discount> _discountRepository;

		public DiscountsService(IRepository<Discount> discountRepository)
		{
			this._discountRepository = discountRepository;
		}

		public async Task<int> Add(InputDiscountViewModel model)
		{
			var discount = new Discount
			{
				Name = model.Name,
				Percent = model.Percent,
			};

			await this._discountRepository.AddAsync(discount);
			var result = await this._discountRepository.SaveChangesAsync();
			return result;
		}

		public IList<DiscountViewModel> All()
		{
			return this._discountRepository.All().Select(d => new DiscountViewModel
			{
				Id = d.Id,
				Name = d.Name,
				Percent = d.Percent
			}).ToList();
		}

		public Discount GetById(int id)
		{
			var ticket = this._discountRepository.All().FirstOrDefault(d => d.Id == id);
			return ticket;
		}
	}
}
