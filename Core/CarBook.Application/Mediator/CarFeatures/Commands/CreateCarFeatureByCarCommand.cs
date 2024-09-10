using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarFeatures.Commands;

public class CreateCarFeatureByCarCommand : IRequest
{
    public int CarId { get; set; }
    public int FeatureId { get; set; }
    public bool Avaible { get; set; }

    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _repository;
        IMapper _mapper;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            request.Avaible = true;
            var mappedavlues = _mapper.Map<CarFeature>(request);
            mappedavlues.Avaible = true;
            _repository.CreateCarFeatureByCar(mappedavlues);
        }
    }
}
