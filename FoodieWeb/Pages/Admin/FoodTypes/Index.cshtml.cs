using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        public IEnumerable<FoodType> categories;
        public IndexModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            categories = dbContext.FoodTypes.GetAll();
        }
    }
}
