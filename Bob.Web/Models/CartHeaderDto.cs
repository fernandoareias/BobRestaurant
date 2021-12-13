﻿using System;

namespace Bob.Web.Models
{
    public class CartHeaderDto
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

    }
}
