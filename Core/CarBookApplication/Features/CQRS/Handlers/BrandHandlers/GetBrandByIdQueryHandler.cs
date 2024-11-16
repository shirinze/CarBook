using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Queries.BrandQuery;
using CarBookApplication.Features.CQRS.Results.BrandResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repositry;

        public GetBrandByIdQueryHandler(IRepository<Brand> repositry)
        {
            _repositry = repositry;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value=await _repositry.GetByIDAsync(query.Id);
            return new GetBrandByIdQueryResult 
            { 
                BrandID=value.BrandID,
                Name=value.Name,

            };


        }
    }
}
