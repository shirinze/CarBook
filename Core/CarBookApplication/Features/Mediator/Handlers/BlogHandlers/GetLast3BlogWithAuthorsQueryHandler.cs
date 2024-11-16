using CarBookApplication.Features.CQRS.Results.CarResults;
using CarBookApplication.Features.Mediator.Queries.BlogQueries;
using CarBookApplication.Features.Mediator.Results.BlogResults;
using CarBookApplication.Interfaces.BlogInterfaces;
using CarBookApplication.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogsWithAuthor();
            return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
            {
                AuthorID = x.AuthorID,
                BlogID = x.BlogID,
                AuthorName = x.Author.Name,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                CreatedDate = x.CreatedDate,
            }).ToList();
        }
    }
}
