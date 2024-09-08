using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface IStatsRepository
    {
        Task<decimal> AverageDailyCarPrice();
        Task<decimal> AverageWeeklyCarPrice();
        Task<decimal> AverageMonthlyCarPrice();
        Task<decimal> AverageHourlyCarPrice();
        int AutoTransmissionCarCount();
        Task<(string BrandName, int CarCount)> BrandWithMostCarAndCount();
        Task<(string BlogName, int CommentCount)> BlogWithMostCommentAndCount();
        Task<int> LessThan50000KmCarCount();
        Task<int> GasolineOrDieselCount();
        Task<int> HybridCount();
        Task<(string Name , decimal Price, string Model , string Image)> DailyCheapestCar();
        Task<(string Name , decimal Price, string Model,  string Image)> DailyMostExpensiveCar();
    }
}
