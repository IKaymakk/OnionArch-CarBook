using CarBook.Application.Dtos;
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
    public class CarFilteretListQuery : IRequest<List<CarFilterDto>>
    {

        public string? bodytype;
        public string? sort;
        public int? brandid;
        public string? search;
        public string? fuel;
        public int? minkm;
        public int? maxkm;
       

        public CarFilteretListQuery(string? bodytype, string? sort, int? brandid, string? search, string? fuel, int? maxkm, int? minkm)
        {
            this.bodytype = bodytype;
            this.sort = sort;
            this.brandid = brandid;
            this.search = search;
            this.fuel = fuel;
            this.maxkm = maxkm;
            this.minkm = minkm;
        }

        public class CarFilteretListQueryHandler : IRequestHandler<CarFilteretListQuery, List<CarFilterDto>>
        {
            private readonly ICarPricingRepository _carPricingRepository;

            public CarFilteretListQueryHandler(ICarPricingRepository carPricingRepository)
            {
                _carPricingRepository = carPricingRepository;
            }

            public async Task<List<CarFilterDto>> Handle(CarFilteretListQuery request, CancellationToken cancellationToken)
            {
                var options = new CarFilterOptions
                {
                    bodytype = request.bodytype,
                    sort = request.sort,
                    brandid = request.brandid,
                    search = request.search,
                    fuel = request.fuel,
                    minkm = request.minkm,
                    maxkm = request.maxkm
                };


                var values = await _carPricingRepository.GetCarFilterList(options);
                return values.Select(x => new CarFilterDto
                {
                    bodyType = x.Car.BodyType,
                    brandId = x.Car.BrandId,
                    brandName = x.Car.Brand.Name,
                    carId = x.Car.CarId,
                    carModel = x.Car.Model,
                    coverImageUrl = x.Car.CoverImageUrl,
                    dailyAmount = x.Amount,
                    carFuel = x.Car.Fuel,
                    carTransmission = x.Car.Transmission
                }).ToList();
            }
        }
    }
}
