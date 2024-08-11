using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Services.Commands
{
    public class RemoveServiceCommand:IRequest
    {
        public int id { get; set; }

        public RemoveServiceCommand(int id)
        {
            this.id = id;
        }

        public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
        {
            IRepository<Service> _repository;
            IMapper _mapper;

            public RemoveServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.id);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
