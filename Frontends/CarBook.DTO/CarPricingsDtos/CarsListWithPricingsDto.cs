using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarPricingsDtos
{
    public class CarsListWithPricingsDto
    {
        public int CarPricingId { get; set; }
        public string CarModel { get; set; }
        public string BrandName { get; set; }
        public string CarCoverImageUrl { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
