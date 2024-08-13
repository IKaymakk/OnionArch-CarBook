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

public class CarRepository : ICarRepository
{
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<List<Car>> GetCarsListWithBrand()
    {
        var values = await _context.Cars.Include(c => c.Brand).AsNoTracking().ToListAsync();
        return values;
    }

    public async Task<List<Car>> GeTLast5CarsWithBrand()
    {
        var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
        return values;
    }
}
