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
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value=await _repository.GetByIDAsync(command.Id);
           await  _repository.RemoveAsync(value);
        }
    }
}
