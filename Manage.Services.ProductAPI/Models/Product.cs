﻿using System.ComponentModel.DataAnnotations;

namespace Manage.Services.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Range(1, 1000)]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
