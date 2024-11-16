using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.FooterAddressCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIDAsync(request.FooterAddressID);
            values.Description = request.Description;
            values.Address=request.Address;
            values.Phone = request.Phone;
            values.Email = request.Email;
            await _repository.UpdateAsync(values);
        }
    }
}
