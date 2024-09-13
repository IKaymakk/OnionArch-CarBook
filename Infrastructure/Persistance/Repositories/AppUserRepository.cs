using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
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
    public class AppUserRepository : IAppUserRepository
    {
        CarBookContext _carbookContext_;
        public AppUserRepository(CarBookContext ctx)
        {
            _carbookContext_ = ctx;
        }

        public async Task<AppUser> GetByFilterAsync(
     Expression<Func<AppUser, bool>> filter,
     params Expression<Func<AppUser, object>>[] includes)
        {
            // DbSet<AppUser> ile sorguya başla
            IQueryable<AppUser> query = _carbookContext_.Set<AppUser>();

            // Eğer `includes` parametresi sağlanmışsa, dinamik olarak Include işlemlerini ekle
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Filtreyi uygula ve sonuçları listele
            return await query.Where(filter).FirstOrDefaultAsync();
        }

    }
}
