using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork: IDisposable
	{
		CategoryRepository Category { get; }
		FoodTypesRepository FoodTypes { get; }
		MenuItemsRepository MenuItems { get; }
		void Save();
		void Dispose();
	}
}
