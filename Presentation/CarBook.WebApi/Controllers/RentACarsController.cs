using CarBookApplication.Features.Mediator.Queries.RentACarQueries;
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
        public async Task<IActionResult> GetRentACarListByLocation(int locationId, bool available)
        {
            GetRentACarQuery getrentacarquery = new GetRentACarQuery
            {
                Available = available,
                LocationId = locationId
            };
            var value =await _mediator.Send(getrentacarquery);
            return Ok(value);
        }
    }
}
