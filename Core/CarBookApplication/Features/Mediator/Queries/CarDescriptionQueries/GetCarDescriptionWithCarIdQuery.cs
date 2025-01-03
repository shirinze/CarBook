using CarBookApplication.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Queries.CarDescriptionQueries
{
	public class GetCarDescriptionWithCarIdQuery:IRequest<GetCarDescriptionWithCarIdQueryResult>
	{
        public int Id { get; set; }

		public GetCarDescriptionWithCarIdQuery(int id)
		{
			Id = id;
		}
	}
}
