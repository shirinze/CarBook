using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.LocationCommands;
using CarBookApplication.Features.Mediator.Commands.ReviewCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewCommandHandler:IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIDAsync(request.ReviewID);
			value.Comment=request.Comment;
			value.CustomerName = request.CustomerName;
			value.CustomerImage = request.CustomerImage;
			value.ReviewDate=request.ReviewDate;
			value.RatingValue = request.RatingValue;
			value.CarId = request.CarId;
			await _repository.UpdateAsync(value);
		}
	}
}
