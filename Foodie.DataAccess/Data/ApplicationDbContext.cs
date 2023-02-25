
using Foodie.Models;
using Microsoft.EntityFrameworkCore;

namespace Foodie.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Category> Category { get; set; }
		public DbSet<FoodType> FoodType { get; set; }
		public DbSet<MenuItem> MenuItem { get; set; }
	}
}
