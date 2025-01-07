using CarBookApplication.Features.Mediator.Commands.ReviewCommands;
using CarBookApplication.Features.Mediator.Queries.ReviewQueries;
using CarBookApplication.Validator.ReviewValidators;
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

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async Task<IActionResult> GetReviewWithCarId(int id)
		{
			var value = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			CreateReviewValidator validator = new CreateReviewValidator();
			var validationResult = validator.Validate(command);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			await _mediator.Send(command);
			return Ok("eklendi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			await _mediator.Send(command);
			return Ok("Guncellendi");
		}
	}
}
