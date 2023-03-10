using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository.IRepository
{
	public interface IRepository<T>
	{
		// Get All, Get firstordefault, Add, Remove, Update, Remove Range

		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string ? 
			includeProperties = null, 
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
		T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
		void Add(T item);
		void Update(T item);
		void Remove(T item);
		void RemoveRange(IEnumerable<T> items);
	}
}
