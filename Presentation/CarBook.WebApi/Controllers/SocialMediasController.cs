using CarBook.Application.Mediator.SocialMedias.Commands;
using CarBook.Application.Mediator.SocialMedias.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    IMediator mediator;

    public SocialMediasController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetSocialMediasList()
    {
        var values = await mediator.Send(new GetSocialMediasQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
    {
        await mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveSocialMedia(int id)
    {
        await mediator.Send(new RemoveSocialMediaCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSocialMedia(int id)
    {
        var value = await mediator.Send(new GetSocialMediaByIdQuery(id));
        return Ok(value);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
    {
        await mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }
}
