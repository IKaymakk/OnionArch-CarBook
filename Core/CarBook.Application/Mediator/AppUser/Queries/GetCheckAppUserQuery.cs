using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.AppUser.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.AppUser.Queries;

public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<CarBook.Domain.Entities.AppUser> _appuserrepository_;
        private readonly IRepository<AppRole> _approlerepository_;
        public GetCheckAppUserQueryHandler(IRepository<AppRole> approle, IRepository<CarBook.Domain.Entities.AppUser> appuser)
        {
            _approlerepository_ = approle;
            _appuserrepository_ = appuser;
        }
        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            GetCheckAppUserQueryResult result = new();
            var user = await _appuserrepository_.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (user == null)
            {
                result.IsExist = false;
            }
            else
            {
                result.IsExist = true;
                result.Username = user.Username;
                result.RoleName = (await _approlerepository_.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                result.AppUserId = user.AppUserId;
            }
            return result;
        }
    }
}
