using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Results
{
    public class GetBlogWithTagCloudQueryResult
    {
        public int blogId { get; set; }
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public string description { get; set; }
        public string mainImage { get; set; }
        public DateTime createdDate { get; set; }
        public string categoryName { get; set; }
        public List<TagCloudDto> TagClouds { get; set; }
    }

    public class TagCloudDto
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
    }

}

