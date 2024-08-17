using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BrandDtos;

public class CarListByBrand
{

    public string brandname { get; set; }
    public int carId { get; set; }
    public string model { get; set; }
    public int km { get; set; }
    public int year { get; set; }
    public string transmission { get; set; }
    public string fuel { get; set; }
}


