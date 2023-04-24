using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APITest
{
    public class ProductCategoryModel
    {
        [Key]
        public int ProductCategoryId { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}

