using CarBook.Application.Features.Commands.CategoryCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        IRepository<Category> _repository;
        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.Id);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
