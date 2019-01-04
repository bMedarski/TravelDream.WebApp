using System.Linq;
using System.Threading.Tasks;

namespace TravelDream.Data.Common
{
	using System.Collections.Generic;

	public interface IRepository<TEntity>
		where TEntity : class
	{
		IQueryable<TEntity> All();

		Task AddAsync(TEntity entity);

		Task AddRangeAsync(IList<TEntity> entities);

		void Delete(TEntity entity);

		Task<int> SaveChangesAsync();

	}
}