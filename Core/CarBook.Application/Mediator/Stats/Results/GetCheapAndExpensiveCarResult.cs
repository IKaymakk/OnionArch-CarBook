using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Results
{
    public class GetCheapAndExpensiveCarResult
    {
        public string CarName { get; set; }
        public string CarBrand { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
