﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Results
{
    public class GetBlogsByIdQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TagCloudDto> TagClouds { get; set; } // Birden fazla TagCloud için liste
        public int AuthorId { get; set; }
    }
    public class TagCloudDto
    {
        public int TagCloudId { get; set; }
        public string TagCloudTitle { get; set; }
    }
}
