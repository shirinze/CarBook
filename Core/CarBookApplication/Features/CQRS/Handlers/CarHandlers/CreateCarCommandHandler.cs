using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Commands.CarCommands;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car 
            { 
                BigImageUrl= command.BigImageUrl,
                BrandID= command.BrandID,
                Fuel=command.Fuel,
                Km=command.Km,
                Model=command.Model,
                Luggage=command.Luggage,
                Seate=command.Seate,
                Transmission=command.Transmission,
                CoverImageUrl=command.CoverImageUrl
            });

        }
    }
}
