using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BlogDtos
{
    public class BlogWithTagCloudDto
    {
        public int BlogId { get; set; }
        public List<TagCloudDto> TagClouds { get; set; }
    }

    public class TagCloudDto
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
    }
}
