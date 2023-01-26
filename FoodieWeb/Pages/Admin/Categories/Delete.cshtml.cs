using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Pages.Admin.Categories
{
    //	[BindProperties]
    public class DeleteModel : PageModel
    {

		private readonly IUnitOfWork unitOfWork;
		public Category Category { get; set; }
		public DeleteModel(IUnitOfWork unit)
		{
			unitOfWork = unit;
		}
		public IActionResult OnGet(int id)
        {
			var category = unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
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
            var category = unitOfWork.Category.GetFirstOrDefault(x => x.Id == _category.Id);
            if (category != null)
            {
				unitOfWork.Category.Remove(category);
				unitOfWork.Save();
                TempData["success"] = "Category deleted sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
