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

        public async Task AddTagCloudToBlogAsync(int blogId, int tagCloudId)
        {
            var blog = await _context.Blogs
             .Include(b => b.BlogTagClouds)
             .SingleOrDefaultAsync(b => b.BlogId == blogId);


            blog.BlogTagClouds.Add(new BlogTagCloud
            {
                BlogId = blogId,
                TagCloudId = tagCloudId,
            });

            await _context.SaveChangesAsync();
        }

        public async Task<Blog> GetBlogByIdWithAuthorCategoryTagCloud(int blogId)
        {
            var blog = await _context.Blogs
                .Include(x => x.Category) // İlişkili Category verisini yükle
                .Include(x => x.Author)   // İlişkili Author verisini yükle
                .Include(x => x.BlogTagClouds)
                .ThenInclude(x => x.TagClouds)
                .FirstOrDefaultAsync(x => x.BlogId == blogId); // Belirli bir blogu bul
            return blog;
        }

        public async Task<Blog> GetBlogsAuthorDetail(int id)
        {
            var values = await _context.Blogs.Include(x => x.Author).Where(x => x.BlogId == id).FirstOrDefaultAsync();
            return values;
        }

        public async Task<List<Blog>> GetBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(x => x.Category).AsNoTracking().ToListAsync();
            return values;
        }

        public async Task<Blog> GetBlogWithTagCloud(int blogid)
        {
            var value = await _context.Blogs
                           .Include(b => b.BlogTagClouds)
                           .ThenInclude(btc => btc.TagClouds)
                           .SingleOrDefaultAsync(b => b.BlogId == blogid);
            return value;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(x => x.Category).OrderByDescending(x => x.BlogId).Take(3).ToListAsync();
            return values;
        }

        public async Task<TagCloud> GetTagCloudByIdAsync(int tagCloudId)
        {
            var value = await _context.TagClouds.FindAsync(tagCloudId);
            return value;
        }
    }
}
