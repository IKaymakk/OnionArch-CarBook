using CarBook.Domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Authors.Results
{
    public class GetBlogListByAuthorQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
    }
}
