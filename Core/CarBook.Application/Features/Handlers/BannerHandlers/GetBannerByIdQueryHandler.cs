using CarBook.Application.Features.Queries.BannerQueries;
using CarBook.Application.Features.Results.BannerResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BannerHandlers;

public class GetBannerByIdQueryHandler
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task<GetBanneByIdQueryResult> Handle(GetBannerByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        return new GetBanneByIdQueryResult
        {
            Description = value.Description,
            BannerId = value.BannerId,
            Title = value.Title,
            VideoDescription = value.VideoDescription,
            VideoUrl = value.VideoUrl
        };
    }
}
