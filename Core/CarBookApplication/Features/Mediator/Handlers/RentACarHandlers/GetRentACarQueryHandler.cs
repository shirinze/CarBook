using CarBookApplication.Features.Mediator.Queries.RentACarQueries;
using CarBookApplication.Features.Mediator.Results.RentACarResults;
using CarBookApplication.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values= _repository.GetByFilterAsync(x=>x.LocationID==request.LocationId && x.Available==true);
            return values.Select(x => new GetRentACarQueryResult {
                CarId = x.CarId,
                Model=x.Car.Model,
                Brand=x.Car.Brand.Name,
                CoverImageUrl=x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
