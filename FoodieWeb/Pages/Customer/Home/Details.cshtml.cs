using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FoodieWeb.Pages.Customer.Home
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }
        public DetailsModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? Id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCart = new ShoppingCart() {
                ApplicationUserId = claim.Value,
                MenuItem = dbContext.MenuItems.GetFirstOrDefault(x => x.Id == Id, includeProperties: "Category,FoodType"),
                MenuItemId = (int)Id
            };
        }
        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {

                var existingShoppingCart = dbContext.ShoppingCart.GetFirstOrDefault(filter: u => u.ApplicationUserId == ShoppingCart.ApplicationUserId && u.MenuItemId == ShoppingCart.MenuItemId);
                if (existingShoppingCart != null)
                {
                    dbContext.ShoppingCart.IncreaseCount(existingShoppingCart, ShoppingCart.Count);
                }
                else
                {
                    dbContext.ShoppingCart.Add(ShoppingCart);
                    dbContext.Save();
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
