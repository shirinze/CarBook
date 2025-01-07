using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Commands.ReviewCommands
{
	public class UpdateReviewCommand:IRequest
	{
		public int ReviewID { get; set; }
		public string CustomerName { get; set; }
		public string CustomerImage { get; set; }
		public string Comment { get; set; }
		public int RatingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarId { get; set; }
	}
}
