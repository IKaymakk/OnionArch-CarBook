using Domain.Entities;

namespace CarBook.Domain.Entities;

public class Blog
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string? CoverImageUrl { get; set; }
    public string MainImage { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}