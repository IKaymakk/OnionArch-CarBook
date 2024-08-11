using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Features.Commands
{

    public class CreateFeatureCommand : IRequest
    {
        public string Name { get; set; }

        public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
        {
            private readonly IRepository<Feature> _repository;
            IMapper _mapper;

            public CreateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
            {
                var feature = _mapper.Map<Feature>(request);
                await _repository.CreateAsync(feature);
            }
        }

    }
}
