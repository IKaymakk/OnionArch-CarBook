using CarBook.Application.Inferfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _carBookContext;
        private readonly DbSet<T> _dbSet;


        public Repository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
            _dbSet = _carBookContext.Set<T>();
        }

        public async Task<int> Count()
        {
            return await _carBookContext.Set<T>().CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            _carBookContext.Set<T>().Add(entity);
            await _carBookContext.SaveChangesAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _carBookContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _carBookContext.Set<T>().AsNoTracking().ToListAsync();
        }



        public async Task<T> GetByIdAsync(int id)
        {
            return await _carBookContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _carBookContext.Set<T>().Remove(entity);
            await _carBookContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _carBookContext.Set<T>().Update(entity);
            await _carBookContext.SaveChangesAsync();
        }
        public async Task<List<T>> GetAllWithIncludesAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _carBookContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _carBookContext.SaveChangesAsync();
        }
    }
}

