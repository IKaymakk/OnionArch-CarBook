using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos
{
    public class CarFilterOptions
    {
        public string? bodytype { get; set; }
        public string? sort { get; set; }
        public int? brandid { get; set; }
        public string? search { get; set; }
        public string? fuel { get; set; }
        public int? minkm { get; set; } 
        public int? maxkm { get; set; }  
    }
}
