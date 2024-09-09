using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarDtos
{
    public class CarResultDto
    {
        public int CarId { get; set; }
        public int CarPricingId { get; set; }
        public string CarModel { get; set; }
        public string BrandName { get; set; }
        public string CarCoverImageUrl { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
