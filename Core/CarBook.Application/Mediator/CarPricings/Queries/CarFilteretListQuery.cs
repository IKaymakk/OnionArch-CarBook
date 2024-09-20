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
    public class CarFilteretListQuery : IRequest<List<CarFilteretListQueryResult>>
    {

        string? bodytype;
        string? sort;
        int? brandid;
        string? search;

        public CarFilteretListQuery(string? bodytype, string? sort, int? brandid, string? search)
        {
            this.bodytype = bodytype;
            this.sort = sort;
            this.brandid = brandid;
            this.search = search;
        }

        public class CarFilteretListQueryHandler : IRequestHandler<CarFilteretListQuery, List<CarFilteretListQueryResult>>
        {
            private readonly ICarPricingRepository _carPricingRepository;

            public CarFilteretListQueryHandler(ICarPricingRepository carPricingRepository)
            {
                _carPricingRepository = carPricingRepository;
            }

            public async Task<List<CarFilteretListQueryResult>> Handle(CarFilteretListQuery request, CancellationToken cancellationToken)
            {
                var values = await _carPricingRepository.GetCarFilterList(request.bodytype, request.sort, request.brandid,request.search);
                return values.Select(x => new CarFilteretListQueryResult
                {
                    BodyType = x.Car.BodyType,
                    BrandId = x.Car.BrandId,
                    BrandName = x.Car.Brand.Name,
                    CarId = x.Car.CarId,
                    CarModel = x.Car.Model,
                    CoverImageUrl = x.Car.CoverImageUrl,
                    DailyAmount = x.Amount
                }).ToList();
            }
        }
    }
}
