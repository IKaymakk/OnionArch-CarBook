using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BlogDtos
{
    public class BlogDetailTagCloudDto
    {
        public List<TagCloudDto3> TagClouds { get; set; } // Birden fazla TagCloud için liste

        public class TagCloudDto3
        {
            public int TagCloudId { get; set; }
            public string TagCloudTitle { get; set; }
        }
    }
}
