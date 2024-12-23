using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.ReservationCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name=request.Name,
                Surename=request.Surename,
                Email=request.Email,
                Phone=request.Phone,
                Age=request.Age,
                CarID=request.CarID,
                Description=request.Description,
                DriverLicenseYear=request.DriverLicenseYear,
                PickUpLocationID=request.PickUpLocationID,
                DropOffLocationID=request.DropOffLocationID,
                Status="Rezervasyon Alındı"
                
            });
        }
    }
}
