using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Services.Commands;

public class UpdateServiceCommand : IRequest
{
    public int ServiceId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        IRepository<Service> _repository;
        IMapper _mapper;

        public UpdateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
