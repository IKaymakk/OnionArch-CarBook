using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Brands.Results
{
    public class CarListByBrandQueryResult
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
    }
}
