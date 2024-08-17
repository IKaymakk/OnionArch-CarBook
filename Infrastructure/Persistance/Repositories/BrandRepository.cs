using CarBook.Application.Inferfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly CarBookContext _context;

    public BrandRepository(CarBookContext context)
    {
        _context = context;
    }
    public async Task<List<Car>> CarListByBrand(int id)
    {
        var values = await _context.Cars
            .AsNoTracking()
                .Include(x=>x.Brand)
                    .Where(x=>x.BrandId == id)
                        .ToListAsync();
        return values;
    }
}
