using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork unitOfWork;
        public IEnumerable<Category> categories;
        public IndexModel(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public void OnGet()
        {
            categories = unitOfWork.Category.GetAll();
        }
    }
}
