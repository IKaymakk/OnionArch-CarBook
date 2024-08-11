using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Features.Handlers.AboutHandlers;
using CarBook.Application.Features.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly CreateAboutCommandHandler createAboutCommandHandler;
    private readonly GetAboutByIdQueryHandler getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler getAboutQueryHandler;
    private readonly RemoveAboutCommandHandler removeAboutCommandHandler;
    private readonly UpdateAboutCommandHandler updateAboutCommandHandler;

    public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, RemoveAboutCommandHandler removeAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler)
    {
        this.createAboutCommandHandler = createAboutCommandHandler;
        this.getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        this.removeAboutCommandHandler = removeAboutCommandHandler;
        this.updateAboutCommandHandler = updateAboutCommandHandler;
        this.getAboutQueryHandler = getAboutQueryHandler;
    }
    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await getAboutQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
        var values = await getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
    {
        await createAboutCommandHandler.Handle(command);
        return Ok("Yeni Bilgi Eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveAbout(int id)
    {
        await removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
        return Ok("Bilgi Silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
        await updateAboutCommandHandler.Handle(command);
        return Ok("Bilgi Güncellendi");
    }
}
