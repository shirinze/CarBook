using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.TagCloudQueries;
using CarBookApplication.Features.Mediator.Results.TagCloudResults;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                BlogId = value.BlogId,
                TagCloudID = value.TagCloudID,
                Title = value.Title
            };
        }
    }
}
