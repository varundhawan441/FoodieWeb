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
		ApplicationDbContext db = null;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			this.db = db;
		}

		public void UpdateCategoryName(Category category)
		{
			var obj = db.Categories.FirstOrDefault(x => x.Id == category.Id);
			if (obj != null)
			{
				obj.Name = category.Name;
				obj.DisplayOrder = category.DisplayOrder;
			}
		}
	}
}
