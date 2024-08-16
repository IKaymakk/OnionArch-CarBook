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
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Comments>> GetCommentListByBlog(int blogid)
        {
            var values = await _context.Comments
                .AsNoTracking()
                    .Include(x=>x.Blog)
                        .Where(x=>x.BlogId == blogid)
                            .ToListAsync();
            return values;
        }
    }
}
