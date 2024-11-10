using Microsoft.EntityFrameworkCore;
using PropertyInventorySystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : class, new()
    {
        private readonly PropertyInventoryDbContext _context;

        public BaseRepo(PropertyInventoryDbContext context)
        {
            context = _context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
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
