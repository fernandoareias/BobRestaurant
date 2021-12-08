using Bob.Services.ShopCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage.Services.ShopCartAPI
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<CartHeader> CartHeader { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
