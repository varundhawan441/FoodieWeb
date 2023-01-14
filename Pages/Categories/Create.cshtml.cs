using FoodieWeb.Data;
using FoodieWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Pages.Categories
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
                ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
