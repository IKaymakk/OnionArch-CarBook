using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CarFeaturesDtos;

public class CarFeatureListDto
{
    public int carFeatureId { get; set; }
    public string brandName { get; set; }
    public int carId { get; set; }
    public string carModel { get; set; }
    public int featureId { get; set; }
    public string featureName { get; set; }
    public bool avaible { get; set; }

}
