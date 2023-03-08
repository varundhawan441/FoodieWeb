using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		ApplicationDbContext _context;
		public UnitOfWork(ApplicationDbContext context)
		{
			_context= context;
			Category = new CategoryRepository(context);
			FoodTypes = new FoodTypesRepository(context);
			MenuItems = new MenuItemsRepository(context);
			ShoppingCart = new ShoppingCartRepository(context);
		}
		public CategoryRepository Category { get; private set; }
		public FoodTypesRepository FoodTypes { get; private set; }

		public MenuItemsRepository MenuItems { get; private set; }
		public ShoppingCartRepository ShoppingCart { get; private set; }

		public void Save()
		{
			_context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
