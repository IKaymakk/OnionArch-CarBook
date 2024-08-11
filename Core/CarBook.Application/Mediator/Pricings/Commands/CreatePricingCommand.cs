using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Pricings.Commands;

public class CreatePricingCommand:IRequest
{
    public string Name { get; set; }
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        IRepository<Pricing> _repository;
        IMapper _mapper;

        public CreatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Pricing>(request);
            await _repository.CreateAsync(value);
        }
    }
}
