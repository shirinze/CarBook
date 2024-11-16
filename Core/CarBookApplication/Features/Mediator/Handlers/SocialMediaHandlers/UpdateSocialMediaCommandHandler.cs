using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.SocialMediaCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.SocialMediaID);
            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;
            await _repository.UpdateAsync(value);
        }
    }
}
