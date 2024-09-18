using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarBook.DTO.CarPricingsDtos
{
    public class CarBodyTypesDto
    {
        public string SelectedBodyType { get; set; }
        public List<SelectListItem> BodyTypes { get; set; }
    }
}
