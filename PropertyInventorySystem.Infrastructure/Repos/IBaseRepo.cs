using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PropertyInventorySystem.Entities;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public interface IBaseRepo<T> where T : class, new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter = null);

        Task<T> GetByIdWithIncludes(Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);

        Task<PagedResult<T>> GetAllWithIncludesAndPaging(int pageNumber, int pageSize,
            params Expression<Func<T, object>>[] includeProperties);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<int> Delete(T entity);
        Task<List<T>> AddRange(List<T> entity);
        Task<List<T>> UpdateRange(List<T> entity);
    }
}
