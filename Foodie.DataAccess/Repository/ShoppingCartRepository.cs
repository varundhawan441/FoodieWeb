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
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
		ApplicationDbContext context = null;
		public ShoppingCartRepository(ApplicationDbContext db) : base(db)
		{
			context = db;
		}

        public int DecreaseCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            context.SaveChanges();
            return shoppingCart.Count;
        }

        public int IncreaseCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            context.SaveChanges();
            return shoppingCart.Count;
        }
    }
}
