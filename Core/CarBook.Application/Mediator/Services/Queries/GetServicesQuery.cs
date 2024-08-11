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

public class GetServicesQuery : IRequest<List<GetServicesQueryResult>>
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<GetServicesQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        IMapper _mapper;

        public GetServicesQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetServicesQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetServicesQueryResult>>(values);
            return mappedvalues;
        }
    }

}
