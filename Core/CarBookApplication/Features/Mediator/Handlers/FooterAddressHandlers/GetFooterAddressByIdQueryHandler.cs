using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.FooterAddressQueries;
using CarBookApplication.Features.Mediator.Results.FooterAddressResults;
using CarBookApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIDAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = values.FooterAddressID,
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}
