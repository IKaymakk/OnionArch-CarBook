using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.CarPricings.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Queries
{
    public class CarPricingForAdminQuery : IRequest<CarPricingForAdminQueryResult>
    {
        public CarPricingForAdminQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }

        public class CarPricingForAdminQueryHandler : IRequestHandler<CarPricingForAdminQuery, CarPricingForAdminQueryResult>
        {
            private readonly ICarPricingRepository _repository;
            private readonly IMapper _mapper;

            public CarPricingForAdminQueryHandler(ICarPricingRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<CarPricingForAdminQueryResult> Handle(CarPricingForAdminQuery request, CancellationToken cancellationToken)
            {
                var car = await _repository.CarDetailsForAdmin(request.id);
                var mappedCar = _mapper.Map<CarPricingForAdminQueryResult>(car);
                return mappedCar;
            }
        }
    }
}
