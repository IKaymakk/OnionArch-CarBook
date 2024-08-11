using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.SocialMedias.Commands;

public class UpdateSocialMediaCommand : IRequest
{
    public int SocialMediaId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }

    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        IRepository<SocialMedia> _repository;
        IMapper _mapper;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);
        }
    }
}
