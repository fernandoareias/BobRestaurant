using Bob.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bob.Services.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupon { get; set; }
        
    }
}
