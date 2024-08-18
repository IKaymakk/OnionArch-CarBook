using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BlogDtos
{
    public class AdminBlogCreateDto
    {
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public string description { get; set; }
        public string mainImage { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryId { get; set; }
        public int authorId { get; set; }
       
    }
}
