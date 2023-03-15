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
                // Validera att product.productName inte redan finns i DB:n
                if (context.Products.Any(p => p.ProductName == product.ProductName))
                {
                    return product;
                };
                //Console.WriteLine($"Existing product length: {existingProduct}");
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

