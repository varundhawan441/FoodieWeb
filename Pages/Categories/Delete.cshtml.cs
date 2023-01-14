using FoodieWeb.Data;
using FoodieWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Pages.Categories
{
    //	[BindProperties]
    public class DeleteModel : PageModel
    {

        public Category Category { get; set; }
        private readonly ApplicationDbContext dbContext;
        public DeleteModel(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
			if (category != null)
			{
				Category = category;
			}
			else
			{
				return RedirectToPage("Index");
			}
			return Page();
		}

        public async Task<IActionResult> OnPost(Category _category)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == _category.Id);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category deleted sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
