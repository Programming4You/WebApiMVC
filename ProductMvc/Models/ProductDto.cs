using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductMvc.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public CategoryDto Category { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public string Supplier { get; set; }

        [Required]
        [Range(1, 2500)]
        public decimal Price { get; set; }
    }
}