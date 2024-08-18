using CarBook.Application.Features.Queries.CategoryQueries;
using CarBook.Application.Features.Results.CategoryResults;
using CarBook.Application.Inferfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoriesWithBlogCountsQueryHandler
    {
        ICategoryRepository _repository;

        public GetCategoriesWithBlogCountsQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetCategoriesWithBlogCount();
            return values.Select(categories => new GetCategoryQueryResult
            {
                CategoryId = categories.CategoryId,
                Name = categories.Name,
                Count = categories.Blogs.Count()
            }).ToList();
        }
    }
}
