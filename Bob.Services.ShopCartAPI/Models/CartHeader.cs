using System.ComponentModel.DataAnnotations;

namespace Bob.Services.ShopCartAPI.Models
{
    public class CartHeader
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }  
    }
}
