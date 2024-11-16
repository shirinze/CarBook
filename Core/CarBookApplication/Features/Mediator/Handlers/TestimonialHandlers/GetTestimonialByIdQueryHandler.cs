using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.TestimonialQueries;
using CarBookApplication.Features.Mediator.Results.TestimonialResults;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = value.TestimonialID,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                Title = value.Title
            };
        }
    }
}
