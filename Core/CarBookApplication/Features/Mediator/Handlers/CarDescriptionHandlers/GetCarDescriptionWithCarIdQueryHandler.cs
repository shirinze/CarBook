using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.CarDescriptionQueries;
using CarBookApplication.Features.Mediator.Results.CarDescriptionResults;
using CarBookApplication.Interfaces;
using CarBookApplication.Interfaces.CarDescriptionInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionWithCarIdQueryHandler : IRequestHandler<GetCarDescriptionWithCarIdQuery, GetCarDescriptionWithCarIdQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionWithCarIdQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionWithCarIdQueryResult> Handle(GetCarDescriptionWithCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetCarDescriptionByCarId(request.Id);
			return new GetCarDescriptionWithCarIdQueryResult
			{
				CarDescriptionID = value.CarDescriptionID,
				CarID = value.CarID,
				Details = value.Details
			};
		}
	}
}
