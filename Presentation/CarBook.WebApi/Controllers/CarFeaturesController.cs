using CarBook.Application.Mediator.CarFeatures.Commands;
using CarBook.Application.Mediator.CarFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarFeaturesWithCar(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeCarFeatureAvaibleStatus(int id)
        {
            await _mediator.Send(new ChangeCarFeatureAvaibleStatusCommand(id));
            return Ok("Kayıt Güncellendi");
        }
    }
}
