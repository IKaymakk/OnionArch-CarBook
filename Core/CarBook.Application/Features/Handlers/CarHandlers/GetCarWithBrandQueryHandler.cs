using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers;

public class GetCarWithBrandQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = await _repository.GetCarsListWithBrand();
        return values.Select(x => new GetCarWithBrandQueryResult
        {
            BigImageUrl = x.BigImageUrl,
            BrandName = x.Brand.Name,
            BrandId = x.BrandId,
            CarId = x.CarId,
            CoverImageUrl = x.CoverImageUrl,
            Fuel = x.Fuel,
            Km = x.Km,
            Luggage = x.Luggage,
            Year = x.Year,
            Model = x.Model,
            Seat = x.Seat,
            Transmission = x.Transmission
        }).ToList();
    }
}
