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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIDAsync(command.BrandID);
            value.CoverImageUrl = command.CoverImageUrl;
            value.Km = command.Km;
            value.Seate = command.Seate;
            value.Model = command.Model;
            value.Luggage = command.Luggage;
            value.Transmission = command.Transmission;
            value.Fuel = command.Fuel;
            value.BigImageUrl = command.BigImageUrl;
            value.BrandID = command.BrandID;
            await _repository.UpdateAsync(value);
        }
    }
}
