using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProductMvc.Models
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string Name { get; set; }
    }
}