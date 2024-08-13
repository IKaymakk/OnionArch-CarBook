using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Cars.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Cars.Queries
{
    public class GetLast5CarsWithBrandQuery : IRequest<List<GetLast5CarsWithBrandQueryResult>>
    {
        public class GetLast5CarsWithBrandQueryHandler : IRequestHandler<GetLast5CarsWithBrandQuery, List<GetLast5CarsWithBrandQueryResult>>
        {
            private readonly ICarRepository _carRepository;
            IMapper _mapper;

            public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository = carRepository;
                _mapper = mapper;
            }

            public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
            {
                var values = await _carRepository.GeTLast5CarsWithBrand();
                var mappedvalues = _mapper.Map<List<GetLast5CarsWithBrandQueryResult>>(values);
                return mappedvalues;
            }
        }
    }
}
