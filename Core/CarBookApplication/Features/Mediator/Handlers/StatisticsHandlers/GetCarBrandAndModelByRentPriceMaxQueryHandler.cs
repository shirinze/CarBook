using CarBookApplication.Features.Mediator.Queries.StatisticsQueries;
using CarBookApplication.Features.Mediator.Results.StatisticsResults;
using CarBookApplication.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarBrandAndModelByRentPriceMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceMaxQuery, GetCarBrandAndModelByRentPriceMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarBrandAndModelByRentPriceMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceMax();
            return new GetCarBrandAndModelByRentPriceMaxQueryResult { CarBrandAndModelByRentPriceMax = value };
        }
    }
}
