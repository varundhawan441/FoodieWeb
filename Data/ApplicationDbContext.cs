using FoodieWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
