using CarBookApplication.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.StatisticsQueries
{
    public class GetBrandNameByMaxCarQuery:IRequest<GetBrandNameByMaxCarQueryResult>
    {
    }
}
