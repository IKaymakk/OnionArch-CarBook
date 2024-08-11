using CarBook.Application.Mediator.Testimonials.Commands;
using CarBook.Application.Mediator.Testimonials.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController : ControllerBase
{
    IMediator _mediator;

    public TestimonialsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetTestimonialsList()
    {
        var values = await _mediator.Send(new GetTestimonialsQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt GÜncellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveTestimonial(int id)
    {
        await _mediator.Send(new RemoveTestimonialCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTestimonial(int id)
    {
        var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
        return Ok(value);
    }

}
