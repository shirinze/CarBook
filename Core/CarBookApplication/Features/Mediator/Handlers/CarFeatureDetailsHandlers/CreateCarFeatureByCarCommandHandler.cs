using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.CarFeatureCommands;
using CarBookApplication.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.CarFeatureDetailsHandlers
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
             _repository.CreateCarFeatureByCar(new CarFeature
            {
                CarID = request.CarID,
                FeatureID = request.FeatureID,
                Available = false
            });
        }
    }
}
