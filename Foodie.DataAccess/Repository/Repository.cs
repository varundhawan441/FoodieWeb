using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		ApplicationDbContext dbContext = null;
		internal DbSet<T> set;
		public Repository(ApplicationDbContext _dbContext)
		{
			dbContext= _dbContext;
			this.set= _dbContext.Set<T>();
		}
		public void Add(T item)
		{
			dbContext.Add(item);
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> queryable = set;
			return queryable.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> queryable = set;
			if(filter != null)
			{
				queryable = queryable.Where(filter);
			}
			return queryable.FirstOrDefault();
		}

		public void Update(T item)
		{
			dbContext.Update(item);
		}

		public void Remove(T item)
		{
			dbContext.Remove(item);
		}

		public void RemoveRange(IEnumerable<T> items)
		{
			dbContext.RemoveRange(items);
		}
	}
}
