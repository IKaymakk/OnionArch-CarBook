using CarBook.Application.Features.Results.BannerResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.BannerHandlers;

public class GetBannerQueryHandler
{
    private readonly IRepository<Banner> _repository;
    public GetBannerQueryHandler(IRepository<Banner> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(value => new GetBannerQueryResult
        {
            Description = value.Description,
            Title = value.Title,
            BannerId = value.BannerId,
            VideoDescription = value.VideoDescription,
            VideoUrl = value.VideoUrl,
        }).ToList();
    }
}