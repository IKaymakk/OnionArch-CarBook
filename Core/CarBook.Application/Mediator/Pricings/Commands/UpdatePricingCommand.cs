using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Pricings.Commands
{
    public class UpdatePricingCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
        {
            IRepository<Pricing> _repository;
            IMapper _mapper;

            public UpdatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
        }
    }
}
