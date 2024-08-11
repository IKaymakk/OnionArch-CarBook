using CarBook.Application.Mediator.Services.Commands;
using CarBook.Application.Mediator.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    IMediator mediator;

    public ServicesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetServicesList()
    {
        var values = await mediator.Send(new GetServicesQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceCommand command)
    {
        await mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveService(int id)
    {
        await mediator.Send(new RemoveServiceCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetService(int id)
    {
        var value = await mediator.Send(new GetServiceByIdQuery(id));
        return Ok(value);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
    {
        await mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }
}
