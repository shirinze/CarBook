using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.ReviewQueries;
using CarBookApplication.Features.Mediator.Results.ReviewResults;
using CarBookApplication.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery,List< GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository;

		public GetReviewByCarIdQueryHandler(IReviewRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetReviewByCarId(request.Id);
			return value.Select(x => new GetReviewByCarIdQueryResult
			{
				CustomerImage = x.CustomerImage,
				CarId = x.CarId,
				Comment = x.Comment,
				CustomerName = x.CustomerName,
				RatingValue = x.RatingValue,
				ReviewDate = x.ReviewDate,
				ReviewID = x.ReviewID
			}).ToList();
		}
	}
}
