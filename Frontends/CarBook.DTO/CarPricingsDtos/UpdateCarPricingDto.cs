﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarPricingsDtos
{
    public class UpdateCarPricingDto
    {
        public int carId { get; set; }
        public decimal? weeklyAmount { get; set; }
        public decimal? dailyAmount { get; set; }
        public decimal? monthlyAmount { get; set; }
    }
}
