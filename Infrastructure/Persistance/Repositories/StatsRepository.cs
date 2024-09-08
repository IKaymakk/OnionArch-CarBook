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

public class StatsRepository : IStatsRepository
{
    private readonly CarBookContext _context;

    public StatsRepository(CarBookContext context)
    {
        _context = context;
    }

    public int AutoTransmissionCarCount()
    {
        return _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
    }

    public async Task<decimal> AverageDailyCarPrice()
    {
        var value = await _context.CarPricings.Where(x => x.PricingId == 3).AverageAsync(x => x.Amount);
        return value;
    }

    public Task<decimal> AverageHourlyCarPrice()
    {
        var value = _context.CarPricings.Where(x => x.PricingId == 1).AverageAsync(x => x.Amount);
        return value;
    }

    public Task<decimal> AverageMonthlyCarPrice()
    {
        var value = _context.CarPricings.Where(x => x.PricingId == 5).AverageAsync(x => x.Amount);
        return value;
    }

    public Task<decimal> AverageWeeklyCarPrice()
    {
        var value = _context.CarPricings.Where(x => x.PricingId == 4).AverageAsync(x => x.Amount);
        return value;
    }

    public async Task<(string BlogName, int CommentCount)> BlogWithMostCommentAndCount()
    {
        var values = await _context.Blogs
            .OrderByDescending(x => x.Comments.Count())
            .Select(x => new
            {
                BlogName = x.Title,
                CommentCount = x.Comments.Count()
            })
            .FirstOrDefaultAsync();

        return (values.BlogName, values.CommentCount);
    }

    public async Task<(string BrandName, int CarCount)> BrandWithMostCarAndCount()
    {
        var result = await _context.Brands
            .OrderByDescending(x => x.Cars.Count())
            .Select(x => new
            {
                BrandName = x.Name,
                CarCount = x.Cars.Count()
            })
            .FirstOrDefaultAsync();

        return (result.BrandName, result.CarCount);
    }



    public async Task<int> GasolineOrDieselCount()
    {
        return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
    }

    public async Task<int> HybridCount()
    {
        return await _context.Cars.Where(x => x.Fuel == "Hybrid").CountAsync();
    }

    public async Task<int> LessThan50000KmCarCount()
    {
        return await _context.Cars.AsNoTracking().Where(x => x.Km <= 50000).CountAsync();
    }

    public async Task<(string Name, decimal Price, string Model, string Image)> DailyMostExpensiveCar()
    {
        var result = await _context.CarPricings
            .Where(x => x.PricingId == 1)
            .OrderByDescending(x => x.Amount)
            .Select(x => new
            {
                Name = x.Car.Model,
                Price = x.Amount,
                Model = x.Car.Brand.Name,
                Image = x.Car.CoverImageUrl
            })
            .FirstOrDefaultAsync();
        return (result.Name, result.Price, result.Model, result.Image);
    }
    public async Task<(string Name, decimal Price, string Model, string Image)> DailyCheapestCar()
    {
        var result = await _context.CarPricings
           .Include(x => x.Car)
            .ThenInclude(x => x.Brand)
           .Where(x => x.PricingId == 1)
           .OrderBy(x => x.Amount)
           .Select(x => new
           {
               Name = x.Car.Model,
               Price = x.Amount,
               Model = x.Car.Brand.Name,
               Image = x.Car.CoverImageUrl
           })
           .FirstOrDefaultAsync();
        return (result.Name, result.Price, result.Model, result.Image);
    }


}
