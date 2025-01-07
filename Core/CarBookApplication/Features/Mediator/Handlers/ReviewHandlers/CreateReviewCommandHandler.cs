using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.LocationCommands;
using CarBookApplication.Features.Mediator.Commands.ReviewCommands;
using CarBookApplication.Interfaces;
using CarBookApplication.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Review
			{
				Comment = request.Comment,
				CarId = request.CarId,
				CustomerImage = request.CustomerImage,
				CustomerName = request.CustomerName,
				RatingValue = request.RatingValue,
				ReviewDate = DateTime.Parse(DateTime.Now.ToShortDateString())
			});
		}
		
	}
}
