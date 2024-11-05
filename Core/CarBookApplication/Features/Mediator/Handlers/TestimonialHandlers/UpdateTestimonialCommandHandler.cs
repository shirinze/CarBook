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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.TestimonialID);
            value.Comment = request.Comment;
            value.Title = request.Title;
            value.ImageUrl = request.ImageUrl;
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
