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
    public class GetCarPricingWithCarsQueryHandler : IRequestHandler<GetCarPricingWithCarsQuery, List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithCarsQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithCars();
            return values.Select(x => new GetCarPricingWithCarsQueryResult
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingID = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model
            }).ToList();

        }
    }
}
