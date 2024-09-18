using CarBook.Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> CarPricingsWithCars();
        Task<List<(string BrandName, string CarModel, string CoverImageUrl, decimal? DailyAmount, decimal? WeeklyAmount, decimal? MonthlyAmount,int CarId)>> CarsListWithPricings();
        Task<Application.Dtos.CarsDetailForAdminDto> CarDetailsForAdmin(int id);
        Task<List<CarPricing>> GetCarListByBrandId(int id);
        
    }
}
