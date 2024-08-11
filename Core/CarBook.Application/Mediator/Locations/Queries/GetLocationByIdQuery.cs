using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Locations.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Locations.Queries;

public class GetLocationByIdQuery:IRequest<GetLocationByIdQueryResult>
{
    public int Id { get; set; }

    public GetLocationByIdQuery(int id)
    {
        Id = id;
    }

    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        IRepository<Location> _repository;
        IMapper _mapper;

        public GetLocationByIdQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var mappedvalue = _mapper.Map<GetLocationByIdQueryResult>(value);
            return mappedvalue;
        }
    }
}
