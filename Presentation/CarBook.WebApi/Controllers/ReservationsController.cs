using CarBook.Application.Mediator.Reservations.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    IMediator _mediator;

    public ReservationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Rezervasyon Başarıyla Eklendi");
    }
}
