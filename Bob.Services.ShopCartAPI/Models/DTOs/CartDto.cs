using System.Collections.Generic;

namespace Bob.Services.ShopCartAPI.Models.Dto
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
