using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.CarFeatureDetailsQueries;
using CarBookApplication.Features.Mediator.Results.CarFeatureDeatilResults;
using CarBookApplication.Interfaces;
using CarBookApplication.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.CarFeatureDetailsHandlers
{
    public class GetCarFeatureDetailByCarIdQueryHandler : IRequestHandler<GetCarFeatureDetailByCarIDQuery, List<GetCarFeatureDetailByCarIDQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureDetailByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureDetailByCarIDQueryResult>> Handle(GetCarFeatureDetailByCarIDQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeatureByCarId(request.Id);
            return values.Select(x => new GetCarFeatureDetailByCarIDQueryResult
            {
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName=x.Feature.Name
            }).ToList();
        }
    }
}
