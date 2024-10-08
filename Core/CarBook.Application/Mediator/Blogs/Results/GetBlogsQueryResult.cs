﻿using CarBook.Domain.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Results
{
    public class GetBlogsQueryResult
    {

        public int blogId { get; set; }
        public string title { get; set; }
        public string coverImageUrl { get; set; }
        public string description { get; set; }
        public string mainImage { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public int authorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
    }
}

