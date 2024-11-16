using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.AuthorCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.AuthorID);
            value.Description = request.Description;
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
