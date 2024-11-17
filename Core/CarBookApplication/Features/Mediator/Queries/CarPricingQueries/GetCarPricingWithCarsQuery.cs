using CarBookApplication.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarsQuery:IRequest<List<GetCarPricingWithCarsQueryResult>>
    {
    }
}
