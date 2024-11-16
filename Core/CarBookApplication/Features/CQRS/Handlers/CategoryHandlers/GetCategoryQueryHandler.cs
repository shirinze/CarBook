using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Results.CategoryResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                Name = x.Name
            }).ToList();
        }
    }
}
