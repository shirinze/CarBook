using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.AuthorQueries;
using CarBookApplication.Features.Mediator.Results.AuthorResults;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorID = value.AuthorID,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Name = value.Name
            };
        }
    }
}
