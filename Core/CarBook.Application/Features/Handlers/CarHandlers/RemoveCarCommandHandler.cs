using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            await _repository.RemoveAsync(values);
        }
    }
}
