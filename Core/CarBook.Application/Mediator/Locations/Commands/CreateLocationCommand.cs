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
    public class CreateLocationCommand:IRequest
    {
        public string Name { get; set; }

        public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
        {

            IRepository<Location> _repository;
            IMapper _mapper;

            public CreateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
            {
                var mappedvalues = _mapper.Map<Location>(request);
                await _repository.CreateAsync(mappedvalues);

                //await _repository.CreateAsync(new Location
                //{
                //    Name = request.Name
                //});

            }
        }
    }
}
