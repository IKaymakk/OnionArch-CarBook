using CarBook.Application.Features.Queries.CarQueries;
using CarBook.Application.Features.Results.CarResults;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Handlers.CarHandlers;

public class GetCarByIdQueryHandler
{
    private readonly ICarRepository _repository;

    public GetCarByIdQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var values = await _repository.GetCarByIdAsync(query.CarId);
        return new GetCarByIdQueryResult
        {
            BodyType = values.BodyType,
            BigImageUrl = values.BigImageUrl,
            BrandId = values.BrandId,
            Year = values.Year,
            CarId = values.CarId,
            CoverImageUrl = values.CoverImageUrl,
            Fuel = values.Fuel,
            Km = values.Km,
            Luggage = values.Luggage,
            Model = values.Model,
            Seat = values.Seat,
            BrandName = values.Brand.Name,
            Transmission = values.Transmission,
            Engine = values.Engine,
            Power = values.Power
        };
    }
}
