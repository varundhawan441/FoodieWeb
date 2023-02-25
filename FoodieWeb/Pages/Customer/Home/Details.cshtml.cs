using Foodie.DataAccess.Repository.IRepository;
using Foodie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FoodieWeb.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork dbContext;
        public MenuItem MenuItems;
        [Required]
        [Range(1, 100, ErrorMessage = "Price should between be 1 to 100")]
        public int Count { get; set; }
        public DetailsModel(IUnitOfWork dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(int? Id)
        {
           MenuItems = dbContext.MenuItems.GetFirstOrDefault(x => x.Id == Id,includeProperties:"Category,FoodType");
        }
    }
}
