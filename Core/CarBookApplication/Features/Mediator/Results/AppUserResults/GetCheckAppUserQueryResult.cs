using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Results.AppUserResults
{
	public class GetCheckAppUserQueryResult
	{
		public int AppUserId { get; set; }
		public string UserName { get; set; }
		public string Role { get; set; }
		public bool IsExist { get; set; }

	}
}
