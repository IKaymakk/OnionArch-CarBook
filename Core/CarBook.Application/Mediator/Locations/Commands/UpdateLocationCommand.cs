using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Locations.Commands
{
    public class UpdateLocationCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
        {
            IRepository<Location> _repository;
            IMapper _mapper;

            public UpdateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);

                //var value = await _repository.GetByIdAsync(request.Id);
                //value.Name = request.Name;
                //await _repository.UpdateAsync(value);
            }
        }
    }
}
