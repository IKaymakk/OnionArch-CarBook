using CarBook.Application.Mediator.Blogs.Commands;
using CarBook.Application.Mediator.Blogs.Queries;
using CarBook.Application.Mediator.Blogs.Commands;
using CarBook.Application.Mediator.Blogs.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarBook.Application.Mediator.Blogs.Results;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetBlogsList()
    {
        var values = await _mediator.Send(new GetBlogsQuery());
        return Ok(values);
    }
    [HttpPost]

    public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Gümcellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveBlog(int id)
    {
        await _mediator.Send(new RemoveBlogCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("GetAllBlogsWithAuthors")]
    public async Task<IActionResult> GetAllBlogsWithAuthors()
    {
        var values = await _mediator.Send(new GetBlogsWithAuthorsQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        var value = await _mediator.Send(new GetBlogsByIdQuery(id));
        return Ok(value);
    }


    [HttpGet("Recent3Blogs")]
    public async Task<IActionResult> GetRecent3Blogs()
    {
        var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
        return Ok(values);
    }
    [HttpGet("blog/{blogid}")]
    public async Task<IActionResult> GetBlogWithTagCloud(int blogid)
    {
        var value = await _mediator.Send(new GetBlogWithTagCloudQuery(blogid));
        return Ok(value);
    }
}

