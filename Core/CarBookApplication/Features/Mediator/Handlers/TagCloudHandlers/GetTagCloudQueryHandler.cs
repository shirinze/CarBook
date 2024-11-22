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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetTagCloudQueryResult
            {
                BlogId = x.BlogId,
                TagCloudID = x.TagCloudID,
                Title = x.Title
            }).ToList();
           
        }
    }
}
