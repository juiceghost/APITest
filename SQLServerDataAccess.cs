using System;
using Microsoft.EntityFrameworkCore;

namespace APITest
{
	public static class SQLServerDataAccess
	{
		public static ProductModel AddProduct(ProductModel product)
		{
            using (var context = new PersonDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        public static List<ProductModel> GetProducts()
        {
            using (var context = new PersonDbContext())
            {
                return context.Products.ToList();  
            }

        }
    }
}

