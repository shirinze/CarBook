using CarBookApplication.Features.Mediator.Results.AuthorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorQuery:IRequest<List<GetAuthorQueryResult>>
    {
    }
}
