using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.Categories
{
    //	[BindProperties]
    public class CreateModel : PageModel
    {

		private readonly IUnitOfWork unitOfWork;
		public Category Category { get; set; }
		public CreateModel(IUnitOfWork unit)
		{
			unitOfWork = unit;
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
                unitOfWork.Category.Add(category);
                unitOfWork.Save();
                TempData["success"] = "Category created sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
