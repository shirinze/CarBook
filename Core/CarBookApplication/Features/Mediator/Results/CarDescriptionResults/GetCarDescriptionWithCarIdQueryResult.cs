using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionWithCarIdQueryResult
	{
		public int CarDescriptionID { get; set; }
		public int CarID { get; set; }
		public string Details { get; set; }
	}
}
