using CarBook.Application.Features.Results.AboutResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.AboutQueries;

public class GetAboutByIdQuery
{
    public GetAboutByIdQuery(int ıd)
    {
        Id = ıd;
    }

    public int Id { get; set; }
}
public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetAboutByIdQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(value => new GetAboutByIdQueryResult
        {
            Title = value.Title,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
        }).ToList();
    }
}