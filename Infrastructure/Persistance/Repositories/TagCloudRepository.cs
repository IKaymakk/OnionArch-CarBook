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

public class TagCloudRepository : ITagCloudRepository
{
    private readonly CarBookContext _context;

    public TagCloudRepository(CarBookContext context)
    {
        _context = context;
    }

    public async Task<TagCloud> GetTagCloudWithBlogsAsync(int tagCloudId)
    {
        return await _context.TagClouds
          .Include(tc => tc.BlogTagClouds)
            .ThenInclude(btc => btc.Blogs)
                .FirstOrDefaultAsync(tc => tc.TagCloudId == tagCloudId);

    }

}
