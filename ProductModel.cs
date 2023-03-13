using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APITest
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [StringLength(30)]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; }
    }
}

