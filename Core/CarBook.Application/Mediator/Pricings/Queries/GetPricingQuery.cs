using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Pricings.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Pricings.Queries;

public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        IRepository<Pricing> repository;
        IMapper mapper;
        public GetPricingQueryHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            var mappedvalues = mapper.Map<List<GetPricingQueryResult>>(values);
            return mappedvalues;
        }
    }
}
