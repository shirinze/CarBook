using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Queries.CarQuery;
using CarBookApplication.Features.CQRS.Results.CarResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIDAsync(query.Id);
            return new GetCarByIdResult
            {
                BigImageUrl = values.BigImageUrl,
                BrandID = values.BrandID,
                CarID = values.CarID,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seate = values.Seate,
                Transmission = values.Transmission
            };
        }
    }
}
