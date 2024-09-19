using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarDtos
{
    public class CarIndexDto
    {
            public int carId { get; set; }
            public int carPricingId { get; set; }
            public string carModel { get; set; }
            public string brandName { get; set; }
            public string carCoverImageUrl { get; set; }
            public string pricingName { get; set; }
            public decimal amount { get; set; }
            public string carBodyType { get; set; }

    }
}
