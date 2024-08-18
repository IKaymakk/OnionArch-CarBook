using CarBook.Application.Features.Results.CategoryResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly IRepository<Category> _repository;

    public GetCategoryQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(categories => new GetCategoryQueryResult
        {
            Name = categories.Name,
        }).ToList();
    }
}
