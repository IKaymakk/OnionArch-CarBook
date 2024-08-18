using CarBook.Application.Inferfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        private readonly CarBookContext _context;

        public StatsRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<decimal> AverageDailyCarPrice()
        {
            var values = await _context.Pricings
                .Include(x => x.CarPricings)
                .ThenInclude(x => x.Car)
                .Where(x => x.PricingId == 3)
               .FirstOrDefaultAsync();

            var averagePrice = values.CarPricings
                  .Average(x => x.Amount);

            return averagePrice;
        }

        public async Task<decimal> AverageHourlyCarPrice()
        {
            var values = await _context.Pricings
                         .Include(x => x.CarPricings)
                         .ThenInclude(x => x.Car)
                         .Where(x => x.PricingId == 1)
                        .FirstOrDefaultAsync();

            var averagePrice = values.CarPricings
                  .Average(x => x.Amount);

            return averagePrice;
        }

        public async Task<decimal> AverageMonthlyCarPrice()
        {
            var values = await _context.Pricings
                           .Include(x => x.CarPricings)
                           .ThenInclude(x => x.Car)
                           .Where(x => x.PricingId == 5)
                          .FirstOrDefaultAsync();

            var averagePrice = values.CarPricings
                  .Average(x => x.Amount);

            return averagePrice;
        }

        public async Task<decimal> AverageWeeklyCarPrice()
        {
            var values = await _context.Pricings
                           .Include(x => x.CarPricings)
                           .ThenInclude(x => x.Car)
                           .Where(x => x.PricingId == 4)
                          .FirstOrDefaultAsync();

            var averagePrice = values.CarPricings
                  .Average(x => x.Amount);

            return averagePrice;
        }
    }
}
