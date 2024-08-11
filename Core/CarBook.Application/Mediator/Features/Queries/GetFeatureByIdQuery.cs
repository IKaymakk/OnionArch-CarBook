using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Features.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CarBook.Application.Mediator.Features.Queries;

public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
{
    public int Id { get; set; }

    public GetFeatureByIdQuery(int id)
    {
        Id = id;
    }

    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        IRepository<Feature> _repository;
        IMapper _mapper;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            var mappedfeature = _mapper.Map<GetFeatureByIdQueryResult>(feature);
            return mappedfeature;

        }
    }
}
