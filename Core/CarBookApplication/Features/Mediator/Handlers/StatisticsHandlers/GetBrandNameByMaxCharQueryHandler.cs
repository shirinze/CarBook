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
    public class GetBrandNameByMaxCharQueryHandler : IRequestHandler<GetBrandNameByMaxCharQuery, GetBrandNameByMaxCharQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandNameByMaxCharQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandNameByMaxCharQueryResult> Handle(GetBrandNameByMaxCharQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandNameByMaxChar();
            return new GetBrandNameByMaxCharQueryResult { BrandNameByMaxChar = value };
        }
    }
}
