using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.FeatureDtos
{
    public class ResultFeatureWithAvaibleDto
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public bool Avaible { get; set; }   
    }
}
