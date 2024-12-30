using CarBookApplication.Features.Mediator.Commands.CarFeatureCommands;
using CarBookApplication.Features.Mediator.Queries.BlogQueries;
using CarBookApplication.Features.Mediator.Queries.CarFeatureDetailsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureList(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureDetailByCarIDQuery(id));
            return Ok(values);
        }
        [HttpGet("ChangeCarFeatureAvailableTrue")]
        public async Task<IActionResult> ChangeCarFeatureAvailableTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Guncellendi");
        }
        [HttpGet("ChangeCarFeatureAvailableFalse")]
        public async Task<IActionResult> ChangeCarFeatureAvailableFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Guncellendi");
        }

    }
}
