using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Features.Commands;

public class RemoveFeatureCommand : IRequest
{
  
    public int Id { get; set; }

    public RemoveFeatureCommand(int id)
    {
        Id = id;
    }

    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        IRepository<Feature> _repository;
        IMapper _mapper;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(feature);
        }
    }
}
