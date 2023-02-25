using Foodie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.DataAccess.Repository.IRepository
{
	public interface IMenuItemssRepository: IRepository<MenuItem>
	{
		void Update(MenuItem item);
	}
}
