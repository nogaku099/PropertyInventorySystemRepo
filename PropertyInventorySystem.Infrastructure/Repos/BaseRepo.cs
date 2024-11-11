using Microsoft.EntityFrameworkCore;
using PropertyInventorySystem.Infrastructure.Context;
using System.Linq.Expressions;
using PropertyInventorySystem.Entities;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class, new()
    {
        private readonly PropertyInventoryDbContext _context;

        public BaseRepo(PropertyInventoryDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }
        
        public async Task<TEntity> GetByIdWithIncludes(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Apply the Include methods dynamically
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(filter);
        }
        
        public async Task<PagedResult<TEntity>> GetAllWithIncludesAndPaging(int pageNumber, int pageSize, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Apply the Include methods dynamically
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            // Get total count of records for paging
            var totalRecords = await query.CountAsync();

            if (pageNumber == 1 && pageSize == -1)
            {
                var lstItem = await query.AsNoTracking().ToListAsync();
                return new PagedResult<TEntity>
                {
                    Items = lstItem,
                    TotalCount = totalRecords,
                    PageNumber = 1,
                    PageSize = totalRecords,
                    TotalPages = 1
                };
            }

            // Apply pagination (Skip and Take)
            var items = await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return the paged result
            return new PagedResult<TEntity>
            {
                Items = items,
                TotalCount = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _context.Set<TEntity>().ToListAsync() : _context.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _context.AddAsync(entity);    
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
            await _context.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
            _context.UpdateRange(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
