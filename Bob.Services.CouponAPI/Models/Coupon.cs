using System.ComponentModel.DataAnnotations;

namespace Bob.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }

    }
}
