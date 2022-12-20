﻿using System.ComponentModel.DataAnnotations;

namespace usingDependenciInjection.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}
