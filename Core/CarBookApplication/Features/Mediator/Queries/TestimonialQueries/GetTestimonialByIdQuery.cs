using CarBookApplication.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
