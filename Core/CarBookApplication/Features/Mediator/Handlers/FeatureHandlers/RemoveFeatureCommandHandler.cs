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
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIDAsync(request.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
