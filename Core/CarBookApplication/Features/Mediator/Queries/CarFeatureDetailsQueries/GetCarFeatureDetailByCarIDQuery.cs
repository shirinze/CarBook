using CarBookApplication.Features.Mediator.Results.CarFeatureDeatilResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.CarFeatureDetailsQueries
{
    public class GetCarFeatureDetailByCarIDQuery:IRequest<List<GetCarFeatureDetailByCarIDQueryResult>>
    {
        public int Id { get; set; }

        public GetCarFeatureDetailByCarIDQuery(int id)
        {
            Id = id;
        }
    }
}
