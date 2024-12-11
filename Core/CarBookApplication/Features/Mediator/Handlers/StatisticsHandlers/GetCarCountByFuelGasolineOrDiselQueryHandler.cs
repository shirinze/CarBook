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
    public class GetCarCountByFuelGasolineOrDiselQueryHandler :IRequestHandler<GetCarCountByFuelGasolineOrDiselQuery, GetCarCountByFuelGasolineOrDiselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelGasolineOrDiselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelGasolineOrDiselQueryResult> Handle(GetCarCountByFuelGasolineOrDiselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelGasolineOrDisel();
            return new GetCarCountByFuelGasolineOrDiselQueryResult { CarCountByFuelGasolineOrDisel = value };
        }
    }
  
}
