using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Services.Commands;

public class CreateServiceCommand:IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        IRepository<Service> _repository;
        IMapper _mapper;

        public CreateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Service>(request);
            await _repository.CreateAsync(value);
        }
    }
}
