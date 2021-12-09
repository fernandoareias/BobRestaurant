﻿namespace Bob.Web.Models
{
    public class CartHeaderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CouponCode { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal DiscountTotal { get; set; }
    }
}
