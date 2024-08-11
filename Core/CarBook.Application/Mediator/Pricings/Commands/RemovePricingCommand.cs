using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Pricings.Commands;

public class RemovePricingCommand : IRequest
{
    public int Id { get; set; }

    public RemovePricingCommand(int ıd)
    {
        Id = ıd;
    }

    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {

        private readonly IRepository<Pricing> _repository;
        
        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
