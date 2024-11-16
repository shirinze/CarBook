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
    public class UpdateBrandCmmandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCmmandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var value = await _repository.GetByIDAsync(command.BrandID);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
