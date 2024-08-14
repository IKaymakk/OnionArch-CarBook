using CarBook.Application;
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

public class CarPricingRepository : ICarPricingRepository
{
    private readonly CarBookContext _context;

    public CarPricingRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<List<CarPricing>> CarPricingsWithCars()
    {
        var values = await _context.CarPricings
                       .Include(x => x.Car)
                           .ThenInclude(x => x.Brand)
                               .Include(z => z.Pricing).Where(x => x.PricingId == 3).AsNoTracking().ToListAsync();
        return values;
    }
}
