using Foodie.DataAccess.Data;
using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodieWeb.Pages.Admin.FoodTypes
{
    //	[BindProperties]
    public class CreateModel : PageModel
    {

        public FoodType FoodType { get; set; }
		private readonly IUnitOfWork dbContext;
		public CreateModel(IUnitOfWork context)
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
                dbContext.FoodTypes.Add(foodType);
                dbContext.Save();
                TempData["success"] = "Food type created sucessfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
