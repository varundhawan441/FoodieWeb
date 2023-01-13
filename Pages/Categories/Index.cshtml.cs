using FoodieWeb.Data;
using FoodieWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Views.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public IEnumerable<Category> categories;
        public IndexModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            categories = dbContext.Categories.ToList();
        }
    }
}
