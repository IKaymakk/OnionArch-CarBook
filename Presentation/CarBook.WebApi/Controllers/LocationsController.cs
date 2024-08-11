using CarBook.Application.Mediator.Locations.Commands;
using CarBook.Application.Mediator.Locations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocationsList()
    {
        var values = await _mediator.Send(new GetLocationQuery());
        return Ok(values);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveLocation(int id)
    {
        await _mediator.Send(new RemoveLocationCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation(int id)
    {
        var value = await _mediator.Send(new GetLocationByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateLocation (UpdateLocationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }
}
