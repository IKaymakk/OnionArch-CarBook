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
    public class CarPricingListQuery : IRequest<List<CarPricingListQueryResult>>
    {
        public class CarPricingListQueryHandler : IRequestHandler<CarPricingListQuery, List<CarPricingListQueryResult>>
        {
            private readonly ICarPricingRepository _repository;
            IMapper _mapper;

            public CarPricingListQueryHandler(ICarPricingRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<CarPricingListQueryResult>> Handle(CarPricingListQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.CarsListWithPricings();
                return values.Select(x => new CarPricingListQueryResult
                {
                    Id = x.CarId,
                    BrandName = x.BrandName,
                    CoverImageUrl = x.CoverImageUrl,
                    DailyAmount = x.DailyAmount,
                    Model = x.CarModel,
                    MonthlyAmount = x.MonthlyAmount,
                    WeeklyAmount = x.WeeklyAmount,
                }).ToList();
            }
        }
    }
}
