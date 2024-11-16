using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.FeatureCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIDAsync(request.FeatureID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
            
        }
    }
}
