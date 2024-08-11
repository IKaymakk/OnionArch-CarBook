using CarBook.Application.Features.Commands.CategoryCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    IRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCategoryCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        await _repository.RemoveAsync(value);
    }
}
