using System;
using System.Linq.Expressions;

namespace APITest
{
	public interface IRepositoryBase<T>
	{
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

