using CarBook.Application.Features.Results.CategoryResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CarBookContext _context;

        public CategoryRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesWithBlogCount()
        {
            var categories = await _context.Categories
                .Include(c => c.Blogs) // Blogs navigation property'i dahil ediliyor
                    .Select(c => new Category
                    {
                        Name = c.Name,
                        BlogCount = c.Blogs.Count() // Blog sayısını almak için
                    })
                        .AsNoTracking()
                            .ToListAsync();
            return categories;
        }
    }
}
