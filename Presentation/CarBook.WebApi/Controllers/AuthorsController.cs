using CarBook.Application.Mediator.Authors.Commands;
using CarBook.Application.Mediator.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthorsList()
    {
        var values = await _mediator.Send(new GetAuthorsQuery());
        return Ok(values);
    }
    [HttpGet("BlogListByAuthor{id}")]
    public async Task<IActionResult> GetBlogListByAuthor(int id)
    {
        var values = await _mediator.Send(new GetBlogListByAuthorQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAuthor(CreateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAuthor(UpdateAuthorCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Gümcellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveAuthor(int id)
    {
        await _mediator.Send(new RemoveAuthorCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var value = await _mediator.Send(new GetAuthorByIdQuery(id));
        return Ok(value);
    }
}
