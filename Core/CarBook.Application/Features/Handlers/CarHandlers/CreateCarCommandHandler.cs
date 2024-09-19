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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BodyType = command.BodyType,
                BigImageUrl = command.BigImageUrl,
                BrandId = command.BrandId,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Model = command.Model,
                Seat = command.Seat,
                Year = command.Year,
                Transmission = command.Transmission,
                Luggage = command.Luggage,
                
            });
        }
    }
}
