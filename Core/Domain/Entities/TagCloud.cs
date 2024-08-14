using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
        public List<BlogTagCloud> BlogTagClouds { get; set; }

    }
}
