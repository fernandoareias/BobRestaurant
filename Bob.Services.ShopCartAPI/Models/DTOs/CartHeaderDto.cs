using System.ComponentModel.DataAnnotations;

namespace Bob.Services.ShopCartAPI.Models.Dto
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
