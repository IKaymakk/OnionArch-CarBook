using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Features.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Features.Queries;

public class GetFeatureQuery : IRequest<List<GetFeatureQueryResult>>
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;

        public GetFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var features = await _repository.GetAllAsync();
            var mappedResult = _mapper.Map<List<GetFeatureQueryResult>>(features);
            return mappedResult;
        }
    }
}


