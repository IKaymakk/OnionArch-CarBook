using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.FooterAddress.Results;
using CarBook.Application.Mediator.Locations.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Locations.Queries;

public class GetLocationQuery : IRequest<List<GetLocationsQueryResult>>
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationsQueryResult>>
    {
        IRepository<Location> _repository;
        IMapper _mapper;

        public GetLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLocationsQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetLocationsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
