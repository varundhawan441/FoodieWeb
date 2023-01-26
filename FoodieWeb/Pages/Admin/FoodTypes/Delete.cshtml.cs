using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    //	[BindProperties]
    public class DeleteModel : PageModel
    {

        public FoodType FoodType { get; set; }
		private readonly IUnitOfWork dbContext;
		public DeleteModel(IUnitOfWork context)
        {
            dbContext = context;
        }
        public IActionResult OnGet(int id)
        {
			var foodtype = dbContext.FoodTypes.GetFirstOrDefault(c => c.Id == id);
			if (foodtype != null)
			{
				FoodType = foodtype;
			}
			else
			{
				return RedirectToPage("Index");
			}
			return Page();
		}

        public async Task<IActionResult> OnPost(FoodType foodType)
        {
            var _foodType = dbContext.FoodTypes.GetFirstOrDefault(x => x.Id == foodType.Id);
            if (_foodType != null)
            {
                dbContext.FoodTypes.Remove(_foodType);
                dbContext.Save();
                TempData["success"] = "Food type deleted sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
