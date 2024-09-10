using CarBook.Application.Mediator.Comment.Commands;
using CarBook.Application.Mediator.Comment.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentListByBlog(int id)
    {
        var values = await _mediator.Send(new CommentListQuery(id));
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return Ok("Yorum Eklendi");
    }
}
