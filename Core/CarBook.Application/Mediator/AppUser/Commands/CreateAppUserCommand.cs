using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.AppUser.Commands;

public class CreateAppUserCommand : IRequest
{
    public enum RoleTypes
    {
        Admin = 1,
        Member = 2,
        Manager = 3
    };
    public string Username { get; set; }
    public string Password { get; set; }

    public class CreateAppuserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<CarBook.Domain.Entities.AppUser> _repository;

        public CreateAppuserCommandHandler(IRepository<Domain.Entities.AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _repository.GetByFilterAsync(u => u.Username == request.Username);

            if (existingUser != null)
            {
                throw new InvalidOperationException("Kullanıcı adı zaten mevcut.");
            }

            await _repository.CreateAsync(new CarBook.Domain.Entities.AppUser
            {
                Password = request.Password,
                Username = request.Username,
                AppRoleId = (int)RoleTypes.Member
            });
        }

    }
}
