using CarBook.Application.Features.Results.AboutResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;

namespace CarBook.Application.Features.Handlers.AboutHandlers;

public class GetAboutQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetAboutQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        return values.Select(value => new GetAboutQueryResult
        {
            Title = value.Title,
            Description = value.Description,
            ImageUrl = value.ImageUrl,
        }).ToList();
    }
}