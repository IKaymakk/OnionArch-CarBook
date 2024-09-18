using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarPricingsDtos
{
    public class CarFilterBodyTypeDto
    {
        public int carId { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public string carModel { get; set; }
        public string coverImageUrl { get; set; }
        public decimal dailyAmount { get; set; }
        public string bodyType { get; set; }

    }
}
