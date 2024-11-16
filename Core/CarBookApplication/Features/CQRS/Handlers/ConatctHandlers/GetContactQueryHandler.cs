using CarBook.Domain.Entities;
using CarBookApplication.Features.CQRS.Results.ContactResults;
using CarBookApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.CQRS.Handlers.ConatctHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return  values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
