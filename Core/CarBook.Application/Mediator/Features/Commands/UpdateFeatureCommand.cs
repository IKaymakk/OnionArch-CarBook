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

public class UpdateFeatureCommand : IRequest
{
    public int FeatureId { get; set; }
    public string Name { get; set; }

    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        IRepository<Feature> _repository;
        IMapper _mapper;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.FeatureId);
            _mapper.Map(request, feature);
            await _repository.UpdateAsync(feature);
        }
    }
}
