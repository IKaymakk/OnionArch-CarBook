using CarBook.Application;
using CarBook.Application.Dtos;
using CarBook.Application.Inferfaces;
using CarBook.Persistance.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public async Task<List<(string BrandName, string CarModel, string CoverImageUrl, decimal? DailyAmount, decimal? WeeklyAmount, decimal? MonthlyAmount, int CarId, string BodyType)>> CarsListWithPricings()
    {
        //Aracın Bilgilerini Aracın Günlük Fiyatı Filtresi Üzerinden Çekiyoruz
        var dailyPricings = await _context.CarPricings
                                 .Include(x => x.Car)
                                     .ThenInclude(x => x.Brand)
                                 .Include(x => x.Pricing)
                                 .Where(x => x.Pricing.Name == "Günlük")
                                 .Select(x => new
                                 {
                                     x.Car.BodyType,
                                     x.CarId,
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
                                         .FirstOrDefault(monthly => monthly.Model == daily.Model)?.MonthlyAmount,
                         CarId: daily.CarId,
                         BodyType: daily.BodyType
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
    public async Task<List<CarPricing>> GetCarListByBrandId(int id)
    {
        return await _context.CarPricings
            .AsNoTracking()
            .Include(x => x.Pricing)
            .Include(x => x.Car)
            .ThenInclude(x => x.Brand)
            .Where(x => x.Car.BrandId == id && x.PricingId == 3)
            .ToListAsync();
    }
    public async Task<Application.Dtos.CarsDetailForAdminDto> CarDetailsForAdmin(int id)
    {
        // Araca Ait Fiyatlandırma Var Mı Diye Bakıyoruz
        var carPricings = await _context.CarPricings
                                         .Include(x => x.Car)
                                         .ThenInclude(x => x.Brand)
                                         .Include(x => x.Pricing)
                                         .Where(x => x.CarId == id)
                                         .ToListAsync();

        // Eğer Araca Ait Fiyat Bulunamasa Default Değerler Atıyoruz (Yeni Eklenen Aracın Fiyat Durumu Bulunmuyor Ve Default Değer Atamış Oluyoruz)
        if (carPricings == null || !carPricings.Any())
        {
            var newCarPricings = new List<CarPricing>
              {
            new CarPricing { CarId = id, PricingId = 3 , Amount = 1 }, // Varsayılan Günlük
            new CarPricing { CarId = id, PricingId = 4, Amount = 1 }, // Varsayılan Haftalık
            new CarPricing { CarId = id,  PricingId = 5 , Amount = 1 }   // Varsayılan Aylık
             };

            await _context.CarPricings.AddRangeAsync(newCarPricings);
            await _context.SaveChangesAsync();

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



            // Haftalık fiyat
            var weeklyPricing2 = carPricings
                                .Where(x => x.PricingId == 4)
                                .Select(x => new
                                {
                                    WeeklyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // Aylık fiyat
            var monthlyPricing2 = carPricings
                                .Where(x => x.PricingId == 5)
                                .Select(x => new
                                {
                                    MonthlyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // DTO
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
        // Eğer Aracın Fiyat Değerleri Varsa Direkt Aracı Çekiyoruz
        else
        {

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

            var weeklyPricing = carPricings
                                .Where(x => x.Pricing.Name == "Haftalık")
                                .Select(x => new
                                {
                                    x.Car.Model,
                                    WeeklyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            var monthlyPricing = carPricings
                                .Where(x => x.Pricing.Name == "Aylık")
                                .Select(x => new
                                {
                                    x.Car.Model,
                                    MonthlyAmount = (decimal)x.Amount
                                })
                                .FirstOrDefault();

            // DTO
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
    public async Task<List<CarPricing>> GetCarListByBodyType(string bodytype)
    {
        return await _context.CarPricings
                   .AsNoTracking()
                   .Include(x => x.Pricing)
                   .Include(x => x.Car)
                   .ThenInclude(x => x.Brand)
                   .Where(x => x.Car.BodyType == bodytype && x.PricingId == 3)
                   .ToListAsync();
    }
    public async Task<List<CarPricing>> GetCarFilterList(CarFilterOptions options)
    {
        var query = _context.CarPricings
                            .AsNoTracking()
                            .Include(x => x.Car)
                            .ThenInclude(x => x.Brand)
                            .Include(x => x.Pricing)
                            .Where(x => x.Pricing.Name == "Günlük");

        if (options.bodytype != null)
        {
            query = query.Where(x => x.Car.BodyType == options.bodytype);
        }
        if (options.fuel != null)
        {
            query = query.Where(x => x.Car.Fuel == options.fuel);
        }

        if (options.brandid != null)
        {
            query = query.Where(x => x.Car.BrandId == options.brandid);
        }

        if (options.sort == "asc")
        {
            query = query.OrderBy(x => x.Amount);
        }

        else if (options.sort == "desc")
        {
            query = query.OrderByDescending(x => x.Amount);
        }

        if (options.minkm.HasValue && options.maxkm.HasValue)
        {
            query = query.Where(x => x.Car.Km >= options.minkm.Value && x.Car.Km <= options.maxkm.Value);
        }
        else if (options.minkm.HasValue)
        {
            query = query.Where(x => x.Car.Km >= options.minkm.Value);
        }
        else if (options.maxkm.HasValue)
        {
            query = query.Where(x => x.Car.Km <= options.maxkm.Value);
        }

        if (!string.IsNullOrEmpty(options.search))
        {
            options.search = options.search.Trim();  // Boşlukları temizle
            var searchTerms = options.search.Split(' ');

            // Eğer birden fazla kelime varsa
            if (searchTerms.Length > 1)
            {
                var brandName = searchTerms[0];  // İlk kelimeyi marka adı olarak al
                var modelName = searchTerms[1];   // İkinci kelimeyi model adı olarak al

                query = query.Where(c => c.Car.Brand.Name.Contains(brandName) &&
                                         c.Car.Model.Contains(modelName));
            }
            else // Tek kelime ise direkt ara
            {
                query = query.Where(c => c.Car.Brand.Name.Contains(options.search) ||
                                         c.Car.Model.Contains(options.search));
            }
        }
        return await query.ToListAsync();

    }


}