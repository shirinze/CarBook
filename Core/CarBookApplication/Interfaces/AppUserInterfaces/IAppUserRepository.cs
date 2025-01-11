using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Interfaces.AppUserInterfaces
{
	public interface IAppUserRepository
	{
		AppUser GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
	}
}
