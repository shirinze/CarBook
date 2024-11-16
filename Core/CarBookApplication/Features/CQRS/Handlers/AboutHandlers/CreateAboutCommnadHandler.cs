using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Commands.AboutCommands;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommnadHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommnadHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAboutCommnad command)
        {
            await _repository.CreateAsync(new About
            {
                Title = command.Title,
                Description = command.Description,
                ImageUrl = command.ImageUrl
            });
        }
    }
}
