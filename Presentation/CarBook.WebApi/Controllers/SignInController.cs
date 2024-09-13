using CarBook.Application.Mediator.AppUser.Queries;
using CarBook.Application.ServiceRegistration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SignInController : ControllerBase
{
    private readonly IMediator _mediator;

    public SignInController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Index(GetCheckAppUserQuery query)
    {
        var values = await _mediator.Send(query);
        if (values.IsExist)
        {
            return Created("", JwtTokenGenerator.GenerateToken(values));
        }
        else
        {
            return BadRequest("Giriş Bilgileri Hatalı");
        }
    }
}
