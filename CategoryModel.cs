using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APITest
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [StringLength(30)]
        [DisplayName("Category Description")]
        public string CategoryDescription { get; set; }

        public List<ProductCategoryModel> ProductCategories { get; set; }
    }
}

