using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> CarPricingsWithCars();
        Task<List<(string BrandName, string CarModel, string CoverImageUrl, decimal? DailyAmount, decimal? WeeklyAmount, decimal? MonthlyAmount)>> CarsListWithPricings();
    }
}
