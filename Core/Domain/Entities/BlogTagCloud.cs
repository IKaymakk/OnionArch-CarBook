using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class BlogTagCloud
    {
        public int BlogId { get; set; }
        public Blog Blogs { get; set; }
        public int TagCloudId { get; set; }
        public TagCloud TagClouds { get; set; }
    }
}
