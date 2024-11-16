using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.ServiceCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.ServiceID);
            value.Description= request.Description;
            value.Title=request.Title;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
