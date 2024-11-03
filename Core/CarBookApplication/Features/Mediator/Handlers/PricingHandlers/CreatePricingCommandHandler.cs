using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.PricingCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatepricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatepricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Pricing { Name=request.Name });
        }
    }
}
