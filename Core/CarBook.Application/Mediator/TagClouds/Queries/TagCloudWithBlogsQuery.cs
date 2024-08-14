using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.TagClouds.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.TagClouds.Queries
{
    public class TagCloudWithBlogsQuery : IRequest<TagCloudWithBlogsQueryResult>
    {
        public TagCloudWithBlogsQuery(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }

        public int TagCloudId { get; set; }


        public class TagCloudWithBlogsQueryHandler : IRequestHandler<TagCloudWithBlogsQuery, TagCloudWithBlogsQueryResult>
        {
            private readonly ITagCloudRepository _repository;
            IMapper _mapper;

            public TagCloudWithBlogsQueryHandler(ITagCloudRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<TagCloudWithBlogsQueryResult> Handle(TagCloudWithBlogsQuery request, CancellationToken cancellationToken)
            {
                var tagCloud = await _repository.GetTagCloudWithBlogsAsync(request.TagCloudId);
                var mappedTagcloud = _mapper.Map<TagCloudWithBlogsQueryResult>(tagCloud);
                return mappedTagcloud;
            }
        }
    }
}
