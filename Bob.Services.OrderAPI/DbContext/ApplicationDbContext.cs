using Bob.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Manage.Services.OrderAPI
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        
    }
}
