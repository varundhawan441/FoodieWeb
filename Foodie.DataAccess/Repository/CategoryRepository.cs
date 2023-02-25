using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		ApplicationDbContext context = null;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			context = db;
		}

		public void UpdateCategoryName(Category category)
		{
			var obj = context.Category.FirstOrDefault(x => x.Id == category.Id);
			if (obj != null)
			{
				obj.Name = category.Name;
				obj.DisplayOrder = category.DisplayOrder;
			}
		}
	}
}
