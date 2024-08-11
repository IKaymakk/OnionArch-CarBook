using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.FooterAddress.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.FooterAddress.Queries;

public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
{

    public int Id { get; set; }

    public GetFooterAddressByIdQuery(int id)
    {
        Id = id;
    }


    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {

        private readonly IMapper _mapper;
        private readonly IRepository<FooterAddresses> _repository;

        public GetFooterAddressByIdQueryHandler(IMapper mapper, IRepository<FooterAddresses> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var mappedvalue = _mapper.Map<GetFooterAddressByIdQueryResult>(value);
            return mappedvalue;
        }
    }
}

