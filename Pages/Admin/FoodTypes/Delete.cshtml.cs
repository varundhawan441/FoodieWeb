using Foodie.DataAccess.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    //	[BindProperties]
    public class DeleteModel : PageModel
    {

        public FoodType FoodType { get; set; }
        private readonly ApplicationDbContext dbContext;
        public DeleteModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var foodtype = dbContext.FoodTypes.FirstOrDefault(c => c.Id == id);
			if (foodtype != null)
			{
				FoodType = foodtype;
			}
			else
			{
				return RedirectToPage("Index");
			}
			return Page();
		}

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            var _foodType = await dbContext.FoodTypes.FirstOrDefaultAsync(x => x.Id == foodType.Id);
            if (_foodType != null)
            {
                dbContext.FoodTypes.Remove(_foodType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food type deleted sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
