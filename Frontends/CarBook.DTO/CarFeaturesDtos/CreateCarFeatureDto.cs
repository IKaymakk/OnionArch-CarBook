using CarBook.DTO.FeatureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarFeaturesDtos
{
    public class CreateCarFeatureDto
    {
        public List<ResultFeatureWithAvaibleDto> Features { get; set; }
        public int CarId { get; set; }
    }
}
