using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        public IEnumerable<MenuItem> menuItems;
        public IndexModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            menuItems = dbContext.MenuItems.GetAll();
        }
    }
}
