using CarBook.Application.Inferfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _carBookContext;


        public Repository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
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
    }
}
