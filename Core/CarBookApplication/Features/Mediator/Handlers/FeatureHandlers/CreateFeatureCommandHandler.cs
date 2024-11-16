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
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Feature
            { 
                Name= request.Name 
            });
        }
    }
}
