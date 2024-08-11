using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;

namespace CarBook.Application.Features.Handlers.AboutHandlers;

public class CreateAboutCommandHandler
{
    private readonly IRepository<About> _repository;
    public CreateAboutCommandHandler(IRepository<About> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateAboutCommand command)
    {
        await _repository.CreateAsync(new About
        {
            Title = command.Title,
            Description = command.Description,
            ImageUrl = command.ImageUrl
        });
    }
}


