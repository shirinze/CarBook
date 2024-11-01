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
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            { 
            Email=command.Email,
            Message=command.Message,
            Name=command.Name,
            SendDate=command.SendDate,
            Subject=command.Subject
            });

        }
    }
}
