using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.TagCloudCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIDAsync(request.TagCloudID);
            values.BlogId = request.BlogId;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
