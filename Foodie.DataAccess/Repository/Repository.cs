using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

		public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, 
			string ? includeProperties = null, 
			Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
		{
            IQueryable<T> query = set;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
		}

		public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
		{
			IQueryable<T> query = set;
			if(filter != null)
			{
				query = query.Where(filter);
			}
            if (includeProperties != null)
            {
                //abc,,xyz -> abc xyz
                foreach (var includeProperty in includeProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
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
