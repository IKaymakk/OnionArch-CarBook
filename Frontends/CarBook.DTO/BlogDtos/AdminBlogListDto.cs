using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.BlogDtos;

public class AdminBlogListDto
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string? CoverImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CategoryName { get; set; }
    public string AuthorName { get; set; }
    public string AuthorSurname { get; set; }

}
