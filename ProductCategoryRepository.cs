using System;
namespace APITest
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategoryModel>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}

