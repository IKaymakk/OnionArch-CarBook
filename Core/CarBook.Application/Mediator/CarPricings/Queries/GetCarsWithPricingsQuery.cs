using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.CarPricings.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Queries
{
    public class GetCarsWithPricingsQuery : IRequest<List<GetCarsWithPricingsQueryResult>>
    {
        public class GetCarsWithPricingsQueryHandler : IRequestHandler<GetCarsWithPricingsQuery, List<GetCarsWithPricingsQueryResult>>
        {
            ICarPricingRepository _repository;
            IMapper _mapper;

            public GetCarsWithPricingsQueryHandler(ICarPricingRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetCarsWithPricingsQueryResult>> Handle(GetCarsWithPricingsQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.CarPricingsWithCars();
                var mappedvalues = _mapper.Map<List<GetCarsWithPricingsQueryResult>>(values);
                return mappedvalues;
            }
        }
    }
}
