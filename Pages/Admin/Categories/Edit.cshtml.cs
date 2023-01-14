using Foodie.DataAccess.Data;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.Categories
{
    //	[BindProperties]
    public class EditModel : PageModel
    {

        public Category Category { get; set; }
        private readonly ApplicationDbContext dbContext;
        public EditModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if(category != null)
            {
                Category = category;
            }
            else
            {
                return RedirectToPage("Index");
            }
            return Page();
		}

        public async Task<IActionResult> OnPost(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
