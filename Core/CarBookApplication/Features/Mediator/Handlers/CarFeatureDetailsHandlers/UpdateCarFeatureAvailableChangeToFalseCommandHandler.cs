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
    public class UpdateCarFeatureAvailableChangeToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableChangeToFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
             _repository.ChangeCarFeatureAvailableToFalse(request.Id);
            
        }
    }
}
