using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace FoodieWeb.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        [BindProperty]
        public IEnumerable<ShoppingCart> ShoppingCart { get; set; }
        public double TotalPrice { get; set; }
        public IndexModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            var claimIdentities = (ClaimsIdentity)User.Identity;
            var claim = claimIdentities.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCart = dbContext.ShoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                                                            includeProperties: "MenuItem,MenuItem.Category,MenuItem.FoodType");
                if (ShoppingCart != null)
                {
                    foreach (var item in ShoppingCart)
                    {
                        TotalPrice += item.MenuItem.Price * item.Count;
                    }
                }
            }
        }
        public IActionResult OnPostPlus(int cartId)
        {
            var cartItem = dbContext.ShoppingCart.GetFirstOrDefault(f => f.Id == cartId);
            if (cartItem != null)
            {
                dbContext.ShoppingCart.IncreaseCount(cartItem, 1);
            }
            return RedirectToPage("/Customer/Cart/Index");
        }

        public IActionResult OnPostMinus(int cartId)
        {
            var cartItem = dbContext.ShoppingCart.GetFirstOrDefault(f => f.Id == cartId);
            if (cartItem != null)
            {
                if (cartItem.Count == 1)
                {
                    dbContext.ShoppingCart.Remove(cartItem);
                    dbContext.Save();
                }
                else
                {
                    dbContext.ShoppingCart.DecreaseCount(cartItem, 1);
                }
            }
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cartItem = dbContext.ShoppingCart.GetFirstOrDefault(f => f.Id == cartId);
            if (cartItem != null)
            {
                dbContext.ShoppingCart.Remove(cartItem);
                dbContext.Save();
            }
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}
