using CarBook.Application.Mediator.Contacts.Commands;
using CarBook.Application.Mediator.Contacts.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetContactsList()
    {
        var values = await _mediator.Send(new GetContactsQuery());
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Eklendi");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
        var value = await _mediator.Send(new GetContactByIdQuery(id));
        return Ok(value);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveContact(int id)
    {
        await _mediator.Send(new RemoveContactCommand(id));
        return Ok("Kayıt Silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCommand(UpdateContactCommand command)
    {
        await _mediator.Send(command);
        return Ok("Kayıt Güncellendi");
    }
}
