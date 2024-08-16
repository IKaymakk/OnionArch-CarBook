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
    [HttpGet("{blogid}")]
    public async Task<IActionResult> GetCommentListByBlog(int blogid)
    {
        var values = await _mediator.Send(new CommentListQuery(blogid));
        return Ok(values);
    }
}
