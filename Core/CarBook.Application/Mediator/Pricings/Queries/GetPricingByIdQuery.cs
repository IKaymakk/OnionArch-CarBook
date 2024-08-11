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

namespace CarBook.Application.Mediator.Pricings.Queries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPricingByIdQuery(int id)
        {
            Id = id;
        }
        public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
        {
            IRepository<Pricing> repository;
            IMapper mapper;

            public GetPricingByIdQueryHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                this.repository = repository;
                this.mapper = mapper;
            }

            public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await repository.GetByIdAsync(request.Id);
                var mappedvalue = mapper.Map<GetPricingByIdQueryResult>(value);
                return mappedvalue;
            }
        }
    }
}
