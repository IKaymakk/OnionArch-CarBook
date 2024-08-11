using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Features.Results;
using CarBook.Application.Mediator.FooterAddress.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.FooterAddress.Queries;

public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
{
    public class GetFooterAddressQuerHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        IRepository<FooterAddresses> _repository;
        IMapper _mapper;

        public GetFooterAddressQuerHandler(IRepository<FooterAddresses> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetFooterAddressQueryResult>>(values);
            return mappedvalues;
        }
    }
}
