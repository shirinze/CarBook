using CarBookApplication.Features.Mediator.Queries.BlogQueries;
using CarBookApplication.Features.Mediator.Results.BlogResults;
using CarBookApplication.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _reposiory;

        public GetAllBlogWithAuthorQueryHandler(IBlogRepository reposiory)
        {
            _reposiory = reposiory;
        }

        public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var value =_reposiory.GetAllBlogWithAuthors();
            return value.Select(x => new GetAllBlogWithAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                BlogID = x.BlogID,
                CategoryID = x.CategoryID,
                CategoryName=x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                Details=x.Details,
                AuthorDescription=x.Author.Description,
                AuthorImageUrl=x.Author.ImageUrl
            }).ToList();

        }
    }
}
