using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly CarBookContext _context;
    public AuthorRepository(CarBookContext context)
    {
        _context = context;
    }
    public async Task<List<Blog>> GetBlogListByAuthor(int authorid)
    {
        var bloglist = await _context.Blogs
            .AsNoTracking()
                .Include(x => x.Author)
                    .Include(x => x.Category)
                        .Where(x => x.AuthorId == authorid)
                            .ToListAsync();
        return bloglist;
    }
}
