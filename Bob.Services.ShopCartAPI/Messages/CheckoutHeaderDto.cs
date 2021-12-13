using Bob.Services.ShopCartAPI.Models;
using Bob.Services.ShopCartAPI.Models.Dto;
using System;
using System.Collections.Generic;

namespace Bob.Services.ShopCartAPI.Messages
{
    public class CheckoutHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PickupDateTime { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public int CartTotalItems { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }

    }
}
