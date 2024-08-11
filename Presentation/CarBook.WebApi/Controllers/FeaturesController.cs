using CarBook.Application.Mediator.Features.Commands;
using CarBook.Application.Mediator.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    IMediator _mediator;
    public FeaturesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeaturesList()
    {
        var values = await _mediator.Send(new GetFeatureQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeature(int id)
    {
        var value = await _mediator.Send(new GetFeatureByIdQuery(id));
        return Ok(value);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveFeature(int id)
    {
        await _mediator.Send(new RemoveFeatureCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }


}
