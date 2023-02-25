using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodieWeb.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        public IEnumerable<Category> Category;
        public IEnumerable<MenuItem> MenuItems;
        public IndexModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Category = dbContext.Category.GetAll(orderBy: o => o.OrderBy(c => c.DisplayOrder));
            MenuItems = dbContext.MenuItems.GetAll(includeProperties: "Category,FoodType");
        }
    }
}
