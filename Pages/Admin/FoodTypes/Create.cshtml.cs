using Foodie.DataAccess.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    //	[BindProperties]
    public class CreateModel : PageModel
    {

        public FoodType FoodType { get; set; }
        private readonly ApplicationDbContext dbContext;
        public CreateModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                await dbContext.FoodTypes.AddAsync(foodType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food type created sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
