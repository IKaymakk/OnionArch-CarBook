using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(x => x.Category).AsNoTracking().ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogWithTagCloud(int blogid)
        {
            return await _context.Blogs
                           .Include(x => x.Author)
                           .Include(b => b.BlogTagClouds)
                           .ThenInclude(btc => btc.TagClouds)
                           .SingleOrDefaultAsync(b => b.BlogId == blogid);
        }


        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(x => x.Category).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();
            return values;
        }

    }
}
