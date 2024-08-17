using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Brands.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Brands.Queries;

public class CarListByBrandQuery : IRequest<List<CarListByBrandQueryResult>>
{
    public CarListByBrandQuery(int id)
    {
        this.id = id;
    }

    public int id { get; set; }
    public class CarListByBrandQueryHandler : IRequestHandler<CarListByBrandQuery, List<CarListByBrandQueryResult>>
    {
        private readonly IBrandRepository _repository;

        public CarListByBrandQueryHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CarListByBrandQueryResult>> Handle(CarListByBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.CarListByBrand(request.id);
            return values.Select(x => new CarListByBrandQueryResult
            {
                CarId = x.CarId,
                BrandName  = x.Brand.Name,
                Fuel = x.Fuel,
                Km = x.Km,
                Model = x.Model,
                Transmission = x.Transmission,
                Year = x.Year,
            }).ToList();
        }
    }
}
