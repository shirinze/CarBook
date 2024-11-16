using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Commands.BrandCommands;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
            var value = await _repository.GetByIDAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
