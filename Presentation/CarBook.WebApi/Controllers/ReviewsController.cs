using CarBook.Application.Mediator.Reviews.Commands;
using CarBook.Application.Mediator.Reviews.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewsController(IMediator med)
        {
            _mediator = med;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Kayıt Eklendi");
        }
        [HttpGet]
        public async Task<IActionResult> GetReviewList()
        {
            return Ok(await _mediator.Send(new GetReviewListQuery()));
        }
    }
}
