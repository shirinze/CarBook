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
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand command)
        {
            var values = await _repository.GetByIDAsync(command.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
