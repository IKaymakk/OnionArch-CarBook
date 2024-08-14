using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Results
{
    public class GetBlogWithTagCloudQueryResult
    {
        public List<TagCloud> TagClouds { get; set; }
    }

    //public class TagCloudDto
    //{
    //    public int TagCloudId { get; set; }
    //    public string TagCloudTitle { get; set; }
    //}

}

