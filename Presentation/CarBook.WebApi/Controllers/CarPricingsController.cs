using CarBookApplication.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("CarPricingWithCarsList")]
        public async Task<IActionResult> CarPricingWithCarsList()
        {
            var value = await _mediator.Send(new GetCarPricingWithCarsQuery());
            return Ok(value);
        }
		[HttpGet("CarPricingWithTimePeriodList")]
		public async Task<IActionResult> CarPricingWithTimePeriodList()
		{
			var value = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(value);
		}
	}
}
