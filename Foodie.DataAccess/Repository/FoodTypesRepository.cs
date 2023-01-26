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
	public class FoodTypesRepository: Repository<FoodType>, IFoodTypesRepository
	{
		ApplicationDbContext _context;
		public FoodTypesRepository(ApplicationDbContext context):base(context)
		{
			_context= context;
		}


	}
}
