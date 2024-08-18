using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.AuthorDtos;

public class BlogListByAuthorDto
{
    public int blogId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateTime createdDate { get; set; }
    public string categoryName { get; set; }

}