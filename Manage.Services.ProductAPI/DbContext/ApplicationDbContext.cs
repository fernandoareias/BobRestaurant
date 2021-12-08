using Manage.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage.Services.ProductAPI
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
