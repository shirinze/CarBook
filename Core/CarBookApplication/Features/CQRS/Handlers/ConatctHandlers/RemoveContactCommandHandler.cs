using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Commands.ContactCommands;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.ConatctHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveContactCommand command)
        {
           var value= await _repository.GetByIDAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
