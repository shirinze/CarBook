using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBookApplication.Interfaces.AppUserInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarBookContext _context;

		public AppUserRepository(CarBookContext context)
		{
			_context = context;
		}

		AppUser IAppUserRepository.GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			var values = _context.AppUsers.Where(filter).FirstOrDefault();
			return values;
		}
	}
}
