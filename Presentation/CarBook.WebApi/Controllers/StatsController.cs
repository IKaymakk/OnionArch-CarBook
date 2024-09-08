using AuthorBook.Application.Mediator.Stats.Queries;
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
    [HttpGet("BlogCount")]
    public async Task<IActionResult> BlogCount()
    {
        return Ok(await _mediator.Send(new GetBlogCountQuery()));
    }
    [HttpGet("AuthorCount")]
    public async Task<IActionResult> AuthorCount()
    {
        return Ok(await _mediator.Send(new GetAuthorCountQuery()));
    }
    [HttpGet("BrandCount")]
    public async Task<IActionResult> BrandCount()
    {
        return Ok(await _mediator.Send(new GetBrandCountQuery()));
    }
    [HttpGet("BrandWithMostCarAndCount")]
    public async Task<IActionResult> BrandWithMostCarAndCount()
    {
        return Ok(await _mediator.Send(new GetBrandWithMostCarQuery()));
    }
    [HttpGet("BlogWithMostCommentAndCount")]
    public async Task<IActionResult> BlogWithMostCommentAndCount()
    {
        return Ok(await _mediator.Send(new BlogWithMostCommentAndCountQuery()));
    }
    [HttpGet("LessThan50000KmCarCount")]
    public async Task<IActionResult> LessThan50000KmCarCount()
    {
        return Ok(await _mediator.Send(new LessThan50000KmCarCountQuery()));
    }
    [HttpGet("GetGasolineOrDieselCount")]
    public async Task<IActionResult> GetGasolineOrDieselCount()
    {
        return Ok(await _mediator.Send(new GetGasolineOrDieselCountQuery()));
    }
    [HttpGet("GetDailyMostExpensiveCar")]
    public async Task<IActionResult> GetDailyMostExpensiveCar()
    {
        return Ok(await _mediator.Send(new GetDailyMostExpensiveCarQuery()));
    }
    [HttpGet("GetDailyCheapestCar")]
    public async Task<IActionResult> GetDailyCheapestCar()
    {
        return Ok(await _mediator.Send(new GetDailyCheapestCarQuery()));
    }
}
