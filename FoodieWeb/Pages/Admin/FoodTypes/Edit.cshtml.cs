using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {

        public FoodType FoodType { get; set; }
		private readonly IUnitOfWork dbContext;
		public EditModel(IUnitOfWork context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var foodType = dbContext.FoodTypes.GetFirstOrDefault(c => c.Id == id);
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
                dbContext.Save();
                TempData["success"] = "Food type updated sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
