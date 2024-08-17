using AutoMapper;
using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace CarBook.Application.Features.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        IRepository<Car> _repository;
        IMapper _mapper;

        public UpdateCarCommandHandler(IRepository<Car> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            _mapper.Map(command, values);
            await _repository.UpdateAsync(values);
        }
    }
}
//values.Fuel = command.Fuel;
//values.Km = command.Km;
//values.Year = command.Year;
//values.Seat = command.Seat;
//values.CoverImageUrl = command.CoverImageUrl;
//values.BigImageUrl = command.BigImageUrl;
//values.BrandId = command.BrandId;
//values.Luggage = command.Luggage;
//values.Model = command.Model;
//values.Transmission = command.Transmission;