using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.CarPricingQueries;
using CarBookApplication.Features.Mediator.Results.CarPricingResults;
using CarBookApplication.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingWithTimePeriod();
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Brand=x.Brand,
				Model = x.Model,
				CoverImageUrl=x.CoverImageUrl,
				DailyAmount = x.Amount[0],
				WeeklyAmount = x.Amount[1],
				MonthlyAmount = x.Amount[2],
			}).ToList();
			
		}
	}
}
