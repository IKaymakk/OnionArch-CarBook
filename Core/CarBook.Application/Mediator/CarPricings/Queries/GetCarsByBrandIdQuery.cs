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
    public class GetCarsByBrandIdQuery : IRequest<List<GetCarsByBrandIdQueryResult>>
    {
        public int id { get; set; }

        public GetCarsByBrandIdQuery(int id)
        {
            this.id = id;
        }
        public class GetCarsByBrandIdQueryHandler : IRequestHandler<GetCarsByBrandIdQuery, List<GetCarsByBrandIdQueryResult>>
        {
            private readonly ICarPricingRepository _repository;

            public GetCarsByBrandIdQueryHandler(ICarPricingRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<GetCarsByBrandIdQueryResult>> Handle(GetCarsByBrandIdQuery request, CancellationToken cancellationToken)
            {
                var cars = await _repository.GetCarListByBrandId(request.id);
                return cars.Select(x => new GetCarsByBrandIdQueryResult
                {
                    BodyType = x.Car.BodyType,
                    CarId = x.CarId,
                    BrandId = x.Car.Brand.BrandId,
                    BrandName = x.Car.Brand.Name,
                    CarModel = x.Car.Model,
                    CoverImageUrl = x.Car.CoverImageUrl,
                    DailyAmount = x.Amount
                }).ToList();
            }
        }
    }
}
