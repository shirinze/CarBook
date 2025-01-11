using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Queries.AppUserQueries;
using CarBookApplication.Features.Mediator.Results.AppUserResults;
using CarBookApplication.Interfaces;
using CarBookApplication.Interfaces.AppUserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApplication.Features.Mediator.Handlers.AppUserHandlers
{

	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
		{
			_appUserRepository = appUserRepository;
			_appRoleRepository = appRoleRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.Username && x.Password == request.Password);
			if (user == null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.UserName = request.Username;
				values.AppUserId = user.AppUserId;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).RoleName;
				
			}
			return values;
		}
	}
}
