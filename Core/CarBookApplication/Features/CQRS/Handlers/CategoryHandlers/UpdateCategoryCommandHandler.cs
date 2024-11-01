using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Commands.CategoryCommand;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _repository.GetByIDAsync(command.CategoryID);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
