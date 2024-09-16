using CarBook.Application;
using CarBook.Application.Inferfaces;
using CarBook.Persistance.Dtos;
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

    public async Task<List<(string BrandName, string CarModel, string CoverImageUrl, decimal? DailyAmount, decimal? WeeklyAmount, decimal? MonthlyAmount)>> CarsListWithPricings()
    {
        var dailyPricings = await _context.CarPricings
                                 .Include(x => x.Car)
                                     .ThenInclude(x => x.Brand)
                                 .Include(x => x.Pricing)
                                 .Where(x => x.Pricing.Name == "Günlük")
                                 .Select(x => new
                                 {
                                     x.Car.Brand.Name,
                                     x.Car.Model,
                                     x.Car.CoverImageUrl,
                                     DailyAmount = (decimal?)x.Amount
                                 })
                                 .ToListAsync();

        var weeklyPricings = await _context.CarPricings
                                 .Where(x => x.Pricing.Name == "Haftalık")
                                 .Select(x => new
                                 {
                                     x.Car.Model,
                                     WeeklyAmount = (decimal?)x.Amount
                                 })
                                 .ToListAsync();

        var monthlyPricings = await _context.CarPricings
                                 .Where(x => x.Pricing.Name == "Aylık")
                                 .Select(x => new
                                 {
                                     x.Car.Model,
                                     MonthlyAmount = (decimal?)x.Amount
                                 })
                                 .ToListAsync();

        var result = dailyPricings
                     .Select(daily =>
                     (
                         BrandName: daily.Name,
                         CarModel: daily.Model,
                         CoverImageUrl: daily.CoverImageUrl,
                         DailyAmount: daily.DailyAmount,
                         WeeklyAmount: weeklyPricings
                                        .FirstOrDefault(weekly => weekly.Model == daily.Model)?.WeeklyAmount,
                         MonthlyAmount: monthlyPricings
                                         .FirstOrDefault(monthly => monthly.Model == daily.Model)?.MonthlyAmount
                     ))
                     .ToList();

        return result;
    }




    public async Task<List<CarPricing>> CarPricingsWithCars()
    {
        var values = await _context.CarPricings
                       .Include(x => x.Car)
                           .ThenInclude(x => x.Brand)
                               .Include(z => z.Pricing).Where(x => x.PricingId == 3).AsNoTracking().ToListAsync();
        return values;
    }



    public async Task<Application.Dtos.CarsDetailForAdminDto> CarDetailsForAdmin(int id)
    {
        var car = await _context.CarPricings.Where(x => x.CarId == id).FirstOrDefaultAsync();


        var dailyPricing = await _context.CarPricings
                                       .Include(x => x.Car)
                                           .ThenInclude(x => x.Brand)
                                       .Include(x => x.Pricing)
                                       .Where(x => x.Pricing.Name == "Günlük" && x.CarId == car.CarId)
                                       .Select(x => new
                                       {
                                           x.Car.Brand.Name,
                                           x.Car.Model,
                                           x.Car.CoverImageUrl,
                                           DailyAmount = (decimal)x.Amount
                                       })
                                       .FirstOrDefaultAsync();

        var weeklyPricings = await _context.CarPricings
                                 .Where(x => x.Pricing.Name == "Haftalık" && x.CarId == car.CarId)
                                 .Select(x => new
                                 {
                                     x.Car.Model,
                                     WeeklyAmount = (decimal)x.Amount
                                 })
                                 .FirstOrDefaultAsync();

        var monthlyPricings = await _context.CarPricings
                                 .Where(x => x.Pricing.Name == "Aylık" && x.CarId == car.CarId)
                                 .Select(x => new
                                 {
                                     x.Car.Model,
                                     MonthlyAmount = (decimal)x.Amount
                                 })
                                  .FirstOrDefaultAsync();

        Application.Dtos.CarsDetailForAdminDto dto = new Application.Dtos.CarsDetailForAdminDto
        {
            CarId = car.CarId,
            BrandName = dailyPricing.Name,
            CarModel = dailyPricing.Model,
            CoverImageUrl = dailyPricing.CoverImageUrl,
            DailyAmount = dailyPricing.DailyAmount,
            WeeklyAmount = weeklyPricings.WeeklyAmount,
            MonthlyAmount = monthlyPricings.MonthlyAmount
        };

        return dto;
    }

   
}
