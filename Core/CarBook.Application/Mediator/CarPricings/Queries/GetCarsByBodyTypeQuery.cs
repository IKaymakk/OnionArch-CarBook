using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.CarPricings.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarPricings.Queries;

public class GetCarsByBodyTypeQuery : IRequest<List<GetCarsByBodyTypeQueryResult>>
{
    string BodyType { get; set; }

    public GetCarsByBodyTypeQuery(string bodyType)
    {
        BodyType = bodyType;
    }

    public class GetCarsByBodyTypeQueryHandler : IRequestHandler<GetCarsByBodyTypeQuery, List<GetCarsByBodyTypeQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarsByBodyTypeQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarsByBodyTypeQueryResult>> Handle(GetCarsByBodyTypeQuery request, CancellationToken cancellationToken)
        {
            var carlist = await _repository.GetCarListByBodyType(request.BodyType);
            return carlist.Select(x => new GetCarsByBodyTypeQueryResult
            {
                bodyType = x.Car.BodyType,
                brandId = x.Car.BrandId,
                brandName = x.Car.Brand.Name,
                carId = x.Car.CarId,
                carModel = x.Car.Model,
                coverImageUrl = x.Car.CoverImageUrl,
                dailyAmount = x.Amount
            }).ToList();
        }
    }
}
