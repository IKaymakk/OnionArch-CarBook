using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.AboutHandlers;

public class UpdateAboutCommandHandler
{
    IRepository<About> repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
        this.repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command)
    {
        var values = await repository.GetByIdAsync(command.AboutId);
        values.Description = command.Description;
        values.Title = command.Title;
        values.ImageUrl = command.ImageUrl;
        await repository.UpdateAsync(values);
    }
}
