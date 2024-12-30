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
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
