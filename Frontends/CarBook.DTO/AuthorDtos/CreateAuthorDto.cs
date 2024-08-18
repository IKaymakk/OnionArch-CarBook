using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
    }
}
