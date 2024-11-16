using CarBookApplication.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery:IRequest<List<GetPricingQueryResult>>
    {
    }
}
