using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.FooterAddress.Commands;

public class UpdateFooterAddressCommand : IRequest
{
    public int FooterAddressesId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }

    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {

        IRepository<FooterAddresses> _repository;
        IMapper _mapper;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddresses> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressesId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);
        }
    }
}
