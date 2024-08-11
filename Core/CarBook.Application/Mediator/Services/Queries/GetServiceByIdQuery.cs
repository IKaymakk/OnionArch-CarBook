using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Services.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Services.Queries;

public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
{
    public int Id { get; set; }

    public GetServiceByIdQuery(int id)
    {
        Id = id;
    }

    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        IRepository<Service> _repository;
        IMapper _mapper;

        public GetServiceByIdQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            var mappedvalue =_mapper.Map<GetServiceByIdQueryResult>(value);
            return mappedvalue;
        }
    }
}
