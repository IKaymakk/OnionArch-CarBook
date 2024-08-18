using CarBook.Application.Mediator.Stats.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatsController : ControllerBase
{
    IMediator _mediator;

    public StatsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("CarCount")]
    public async Task<IActionResult> CarCount()
    {
        return Ok(await _mediator.Send(new GetCarCountQuery()));
    }
    [HttpGet("LocationCount")]
    public async Task<IActionResult> LocationCount()
    {
        return Ok(await _mediator.Send(new GetLocationCountQuery()));
    }
    [HttpGet("AverageDailyCarPrice")]
    public async Task<IActionResult> AverageDailyCarPrice()
    {
        return Ok(await _mediator.Send(new GetAverageDailyCarPriceQuery()));
    }
    [HttpGet("AverageMonthlyCarPrice")]
    public async Task<IActionResult> AverageMonthlyCarPrice()
    {
        return Ok(await _mediator.Send(new GetAverageMonthlyCarPriceQuery()));
    }
    [HttpGet("AverageWeeklyCarPrice")]
    public async Task<IActionResult> AverageWeeklyCarPrice()
    {
        return Ok(await _mediator.Send(new GetAverageWeeklyCarPriceQuery()));
    }
    [HttpGet("AverageHourlyCarPrice")]
    public async Task<IActionResult> AverageHourlyCarPrice()
    {
        return Ok(await _mediator.Send(new GetAverageHourlyCarPriceQuery()));
    }

}
