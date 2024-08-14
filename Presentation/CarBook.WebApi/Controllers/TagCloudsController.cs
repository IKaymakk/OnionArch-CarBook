using CarBook.Application.Mediator.TagClouds.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagCloudsController : ControllerBase
{
    IMediator _mediator;

    public TagCloudsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{tagCloudId}")]
   
    public async Task<IActionResult> GetTagCloudsWithBlogs(int tagCloudId)
    {
        var values = await _mediator.Send(new TagCloudWithBlogsQuery(tagCloudId));
        return Ok(values);
    }
}
