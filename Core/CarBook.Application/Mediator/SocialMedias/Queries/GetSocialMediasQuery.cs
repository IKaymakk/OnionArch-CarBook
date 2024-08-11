using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.SocialMedias.Queries;
using CarBook.Application.Mediator.SocialMedias.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.SocialMedias.Queries;

public class GetSocialMediasQuery : IRequest<List<GetSocialMediasQueryResult>>
{
    public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediasQuery, List<GetSocialMediasQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;
        IMapper _mapper;

        public GetSocialMediasQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSocialMediasQueryResult>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetSocialMediasQueryResult>>(values);
            return mappedvalues;
        }
    }
}
