using Foodie.DataAccess.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.Categories
{
    //	[BindProperties]
    public class CreateModel : PageModel
    {

        public Category Category { get; set; }
        private readonly ApplicationDbContext dbContext;
        public CreateModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category created sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
