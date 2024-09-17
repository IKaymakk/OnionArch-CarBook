using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Results
{
    public class GetCarsByBrandIdQueryResult
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CarModel { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
    }
}
