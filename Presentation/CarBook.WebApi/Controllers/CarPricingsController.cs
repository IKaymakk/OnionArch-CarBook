using CarBook.Application.Mediator.CarPricings.Commands;
using CarBook.Application.Mediator.CarPricings.Queries;
using CarBook.Application.Mediator.CarPricings.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarPricingsController : ControllerBase
{
    IMediator _mediator;

    public CarPricingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetCarsWithCarPricing()
    {
        var values = await _mediator.Send(new GetCarsWithPricingsQuery());
        return Ok(values);
    }
    [HttpGet("CarsListForRent")]
    public async Task<IActionResult> GetCarsListForRent()
    {
        var values = await _mediator.Send(new CarPricingListQuery());
        return Ok(values);
    }
    [HttpGet("CarDetailForAdmin" + "{id}")]
    public async Task<IActionResult> CarDetailForAdmin(int id)
    {
        var values = await _mediator.Send(new CarPricingForAdminQuery(id));
        return Ok(values);
    }
    [HttpGet("GetCarsByBrandIdQuery" + "{id}")]
    public async Task<IActionResult> CarListByBrandId(int id)
    {
        var values = await _mediator.Send(new GetCarsByBrandIdQuery(id));
        return Ok(values);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCarDetail(UpdateCarPricingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }
    [HttpGet("GetCarsByBodyTypeQuery")]
    public async Task<IActionResult> GetCarsByBodyTypeQuery(string bodytype)
    {
        var values = await _mediator.Send(new GetCarsByBodyTypeQuery(bodytype));
        return Ok(values);
    }
    [HttpGet("CarFilteredList")]
    public async Task<IActionResult> CarFilteredList(string? bodytype, string? sort, int? brandid, string? search, string? fuel, int? maxkm, int? minkm)
    {
        var values = await _mediator.Send(new CarFilteretListQuery(bodytype, sort, brandid, search, fuel, maxkm, minkm));
        return Ok(values);
    }
}
