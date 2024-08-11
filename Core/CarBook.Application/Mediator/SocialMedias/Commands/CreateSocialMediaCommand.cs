using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.SocialMedias.Commands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
        {
            IRepository<SocialMedia> _repository;
            IMapper _mapper;

            public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var value = _mapper.Map<SocialMedia>(request);
                await _repository.CreateAsync(value);
            }
        }
    }
}
