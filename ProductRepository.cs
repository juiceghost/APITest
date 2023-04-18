using System;
namespace APITest
{
	public class ProductRepository : RepositoryBase<ProductModel>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

