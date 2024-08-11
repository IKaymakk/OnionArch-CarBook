using CarBook.Application.Features.Queries.AboutQueries;
using CarBook.Application.Features.Results.AboutResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;

namespace CarBook.Application.Features.Handlers.AboutHandlers;

public class GetAboutByIdQueryHandler
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
        _repository = repository;
    }
    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.Id);
        return new GetAboutByIdQueryResult
        {
            AboutId = values.AboutId,
            Description = values.Description,
            ImageUrl = values.ImageUrl,
            Title = values.Title,
        };
    }
}