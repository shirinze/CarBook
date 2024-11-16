using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.ServiceQueries;
using CarBookApplication.Features.Mediator.Results.ServiceResults;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIDAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceID = value.ServiceID,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title
            };
        }
    }
}
