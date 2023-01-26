using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.Categories
{
    //	[BindProperties]
    public class EditModel : PageModel
    {

		private readonly IUnitOfWork unitOfWork;
		public Category Category { get; set; }
		public EditModel(IUnitOfWork unit)
		{
			unitOfWork = unit;
		}

		public IActionResult OnGet(int id)
        {
			var category = unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
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
                unitOfWork.Category.UpdateCategoryName(category);
                unitOfWork.Save();
                TempData["success"] = "Category updated sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
