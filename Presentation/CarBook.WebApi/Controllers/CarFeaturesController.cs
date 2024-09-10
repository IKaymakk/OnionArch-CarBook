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
        [HttpGet("ToTrue")]
        public async Task<IActionResult> ChangeCarAvaibleStatusToTrue(int id)
        {
            await _mediator.Send(new ChangeAvaibleStatusToTrueCommand(id));
            return Ok("Kayıt Güncellendi");
        }
        [HttpGet("ToFalse")]
        public async Task<IActionResult> ChangeCarAvaibleStatusToFalse(int id)
        {
            await _mediator.Send(new ChangeAvaibleStatusToFalseCommand(id));
            return Ok("Kayıt Güncellendi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kayıt Eklendi");
        }
    }
}
