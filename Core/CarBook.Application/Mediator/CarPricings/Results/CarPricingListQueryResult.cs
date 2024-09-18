using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Results
{
    public class CarPricingListQueryResult
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal? DailyAmount { get; set; }
        public decimal? WeeklyAmount { get; set; }
        public decimal? MonthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string BodyType{ get; set; }
    }
}
