using LekoShop.Models;
using Microsoft.EntityFrameworkCore;

namespace LekoShop.Data
{
    public class LekoContext:DbContext
    {
        public LekoContext()
        {
        }

        public LekoContext(DbContextOptions<LekoContext> option):base(option) { }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}
