
using Foodie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foodie.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Category> Category { get; set; }
		public DbSet<FoodType> FoodType { get; set; }
		public DbSet<MenuItem> MenuItem { get; set; }
		public DbSet<ApplicationUser> applicationUsers { get; set; }
		public DbSet<ShoppingCart> shoppingCarts { get; set; }
	}
}
