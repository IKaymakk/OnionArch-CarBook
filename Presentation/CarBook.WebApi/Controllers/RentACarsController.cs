using CarBook.Application.Mediator.RentACar.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int LocationId, bool IsAvaible)
        {
            GetRentACarQuery query = new GetRentACarQuery()
            {
                IsAvaible = IsAvaible,
                LocationId = LocationId
            };
            var values = await _mediator.Send(query);
            return Ok(values);
        }
    }
}
