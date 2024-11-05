using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.TestimonialCommands;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
