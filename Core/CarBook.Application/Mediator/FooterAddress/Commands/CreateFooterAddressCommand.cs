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

public class CreateFooterAddressCommand : IRequest
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string EMail { get; set; }

    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddresses> _repository;
        IMapper _mapper;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddresses> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var mappedvalues = _mapper.Map<FooterAddresses>(request);
            await _repository.CreateAsync(mappedvalues);

            //await _repository.CreateAsync(new FooterAddresses
            //{
            //    Address = request.Address,
            //    Phone = request.Phone,
            //    Description = request.Description,
            //    EMail = request.EMail
            //});

        }
    }
}
