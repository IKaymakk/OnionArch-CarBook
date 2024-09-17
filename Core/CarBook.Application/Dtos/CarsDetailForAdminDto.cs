using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos
{
    public class CarsDetailForAdminDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal? DailyAmount { get; set; } // Günlük fiyat
        public decimal? WeeklyAmount { get; set; } // Haftalık fiyat
        public decimal? MonthlyAmount { get; set; } // Aylık fiyat

    }
}