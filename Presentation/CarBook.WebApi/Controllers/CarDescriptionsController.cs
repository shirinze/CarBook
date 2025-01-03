using CarBookApplication.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> CarDescriptionWithCarId(int id)
		{
			var value = await _mediator.Send(new GetCarDescriptionWithCarIdQuery(id));
			return Ok(value);
		}

	}
}
