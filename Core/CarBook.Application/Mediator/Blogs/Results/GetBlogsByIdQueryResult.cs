using System;
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
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
}
