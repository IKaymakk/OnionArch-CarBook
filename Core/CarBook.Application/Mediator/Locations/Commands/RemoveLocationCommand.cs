using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Locations.Commands
{
    public class RemoveLocationCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveLocationCommand(int ıd)
        {
            Id = ıd;
        }

        public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
        {
            IRepository<Location> _repository;

            public RemoveLocationCommandHandler(IRepository<Location> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
