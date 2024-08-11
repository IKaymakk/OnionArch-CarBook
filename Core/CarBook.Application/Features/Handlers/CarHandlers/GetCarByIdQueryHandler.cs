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
    private readonly IRepository<Car> _repository;

    public GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
    {
        var values = await _repository.GetByIdAsync(query.CarId);
        return new GetCarByIdQueryResult
        {
            BigImageUrl = values.BigImageUrl,
            BrandId = values.BrandId,
            CarId = values.CarId,
            CoverImageUrl = values.CoverImageUrl,
            Fuel = values.Fuel,
            Km = values.Km,
            Luggage = values.Luggage,
            Model = values.Model,
            Seat = values.Seat,
            Transmission = values.Transmission
        };
    }
}
