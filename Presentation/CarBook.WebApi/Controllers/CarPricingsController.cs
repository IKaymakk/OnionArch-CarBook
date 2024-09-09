using CarBook.Application.Mediator.CarPricings.Queries;
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
}
