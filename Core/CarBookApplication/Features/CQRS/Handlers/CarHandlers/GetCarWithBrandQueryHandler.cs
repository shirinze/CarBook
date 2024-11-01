using CarBookApplication.Features.CQRS.Results.CarResults;
using CarBookApplication.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _carRepository.GetCarsListBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandName = x.Brand.Name,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seate = x.Seate,
                Transmission = x.Transmission,
                BrandID = x.BrandID,
                CarID = x.CarID
            }).ToList();

        }
    }
}
