using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Dtos
{
    public class CarsDetailForAdminDto
    {
            public string BrandName { get; set; }
            public string CarModel { get; set; }
            public string CoverImageUrl { get; set; }
            public decimal DailyAmount { get; set; }
            public decimal WeeklyAmount { get; set; }
            public decimal MonthlyAmount { get; set; }

    }
}
