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

namespace CarBook.Application.Mediator.SocialMedias.Queries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }

        public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery,GetSocialMediaByIdQueryResult>
        {
            IRepository<SocialMedia> _repository;
            IMapper _mapper;

            public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.Id);
                var mappedvalue = _mapper.Map<GetSocialMediaByIdQueryResult>(value);
                return mappedvalue;
            }
        }
    }
}
