using CarBook.Application;
using CarBook.Application.Inferfaces;
using CarBook.Persistance.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        // İlk carPricing nesnesini çekiyoruz
        var carPricings = await _context.CarPricings
                                         .Include(x => x.Car)
                                         .ThenInclude(x => x.Brand)
                                       .Include(x => x.Pricing)
                                        .Where(x => x.CarId == id)
                                        .ToListAsync();

        if (carPricings == null || !carPricings.Any())
        {
            // Eğer carPricing bulunamazsa yeni 3 kayıt ekliyoruz
            var newCarPricings = new List<CarPricing>
              {
            new CarPricing { CarId = id, PricingId = 3 , Amount = 1 }, // Varsayılan Günlük
            new CarPricing { CarId = id, PricingId = 4, Amount = 1 }, // Varsayılan Haftalık
            new CarPricing { CarId = id,  PricingId = 5 , Amount = 1 }   // Varsayılan Aylık
             };

            // Yeni kayıtları veritabanına ekliyoruz
            await _context.CarPricings.AddRangeAsync(newCarPricings);
            await _context.SaveChangesAsync();

            // Eklenen yeni carPricings'i tekrar çekiyoruz
            carPricings = newCarPricings;


            // Günlük fiyatı çekiyoruz
            var dailyPricing2 = await _context.CarPricings
                                       .Include(x => x.Car)
                                        .ThenInclude(x => x.Brand)
                                        .Include(x => x.Pricing)
                                       .Where(x => x.Pricing.Name == "Günlük" && x.CarId == id)
                                       .Select(x => new
                                       {
                                           x.Car.Brand.Name,
                                           x.Car.Model,
                                           x.Car.CoverImageUrl,
                                           DailyAmount = (decimal)x.Amount
                                       })
                                       .FirstOrDefaultAsync();



            // Haftalık fiyatı çekiyoruz
            var weeklyPricing2 = carPricings
                                .Where(x => x.PricingId ==4)
                                .Select(x => new
                                {
                                    WeeklyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // Aylık fiyatı çekiyoruz
            var monthlyPricing2 = carPricings
                                .Where(x => x.PricingId==5)
                                .Select(x => new
                                {
                                    MonthlyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // DTO'yu oluşturuyoruz
            Application.Dtos.CarsDetailForAdminDto dto2 = new Application.Dtos.CarsDetailForAdminDto
            {
                CarId = id,
                BrandName = dailyPricing2?.Name, // Brand bilgisi
                CarModel = dailyPricing2?.Model, // Model bilgisi
                CoverImageUrl = dailyPricing2?.CoverImageUrl, // Resim URL'si
                DailyAmount = dailyPricing2?.DailyAmount ?? 1, // Günlük fiyat, yoksa varsayılan 1
                WeeklyAmount = weeklyPricing2?.WeeklyAmount ?? 1, // Haftalık fiyat, yoksa varsayılan 1
                MonthlyAmount = monthlyPricing2?.MonthlyAmount ?? 1 // Aylık fiyat, yoksa varsayılan 1
            };

            return dto2;


        }
        else
        {

            // Günlük fiyatı çekiyoruz
            var dailyPricing = carPricings
                                .Where(x => x.Pricing.Name == "Günlük")
                                .Select(x => new
                                {
                                    x.Car.Brand.Name,
                                    x.Car.Model,
                                    x.Car.CoverImageUrl,
                                    DailyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // Haftalık fiyatı çekiyoruz
            var weeklyPricing = carPricings
                                .Where(x => x.Pricing.Name == "Haftalık")
                                .Select(x => new
                                {
                                    x.Car.Model,
                                    WeeklyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // Aylık fiyatı çekiyoruz
            var monthlyPricing = carPricings
                                .Where(x => x.Pricing.Name == "Aylık")
                                .Select(x => new
                                {
                                    x.Car.Model,
                                    MonthlyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // DTO'yu oluşturuyoruz
            Application.Dtos.CarsDetailForAdminDto dto = new Application.Dtos.CarsDetailForAdminDto
            {
                CarId = id,
                BrandName = dailyPricing?.Name, // Brand bilgisi
                CarModel = dailyPricing?.Model, // Model bilgisi
                CoverImageUrl = dailyPricing?.CoverImageUrl, // Resim URL'si
                DailyAmount = dailyPricing?.DailyAmount ?? 1, // Günlük fiyat, yoksa varsayılan 1
                WeeklyAmount = weeklyPricing?.WeeklyAmount ?? 1, // Haftalık fiyat, yoksa varsayılan 1
                MonthlyAmount = monthlyPricing?.MonthlyAmount ?? 1 // Aylık fiyat, yoksa varsayılan 1
            };

            return dto;
        }

    }


}
