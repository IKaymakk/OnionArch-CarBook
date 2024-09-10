using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarFeatures.Results
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int CarFeatureId { get; set; }
        public string BrandName { get; set; }
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Avaible { get; set; }
    }
}
