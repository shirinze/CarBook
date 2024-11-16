using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Queries.CategoryQuery;
using CarBookApplication.Features.CQRS.Results.CategoryResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIDAsync(query.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = value.CategoryID,
                Name = value.Name
            };
        }
    }
}
