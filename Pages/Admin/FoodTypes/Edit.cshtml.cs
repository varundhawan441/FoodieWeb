using Foodie.DataAccess.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {

        public FoodType FoodType { get; set; }
        private readonly ApplicationDbContext dbContext;
        public EditModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var foodType = dbContext.FoodTypes.FirstOrDefault(c => c.Id == id);
            if(foodType != null)
            {
                FoodType = foodType;
            }
            else
            {
                return RedirectToPage("Index");
            }
            return Page();
		}

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext.FoodTypes.Update(FoodType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food type updated sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
