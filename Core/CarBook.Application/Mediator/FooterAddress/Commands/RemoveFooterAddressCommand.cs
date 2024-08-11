using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.FooterAddress.Commands;

public class RemoveFooterAddressCommand:IRequest
{
    public int Id { get; set; }

    public RemoveFooterAddressCommand(int ıd)
    {
        Id = ıd;
    }

    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        readonly IRepository<FooterAddresses> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddresses> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
