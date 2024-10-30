using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Queries.BannerQuery;
using CarBookApplication.Features.CQRS.Results.BannerResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIDAsync(query.Id);
            return new GetBannerByIdQueryResult
            { 
                BannerID=values.BannerID,
                Title=values.Title,
                Description=values.Description,
                VideoDescription=values.VideoDescription,
                VideoUrl=values.VideoUrl
            };

        }
    }
}
