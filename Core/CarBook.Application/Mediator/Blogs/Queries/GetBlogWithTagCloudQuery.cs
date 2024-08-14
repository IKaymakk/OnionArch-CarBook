﻿using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Blogs.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Queries
{
    public class GetBlogWithTagCloudQuery : IRequest<GetBlogWithTagCloudQueryResult>
    {
        public GetBlogWithTagCloudQuery(int blogId)
        {
            BlogId = blogId;
        }

        public int BlogId { get; set; }

        public class GetBlogWithTagCloudQueryHandler : IRequestHandler<GetBlogWithTagCloudQuery, GetBlogWithTagCloudQueryResult>
        {
            private readonly IBlogRepository _repository;
            IMapper _mapper;

            public GetBlogWithTagCloudQueryHandler(IBlogRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetBlogWithTagCloudQueryResult> Handle(GetBlogWithTagCloudQuery request, CancellationToken cancellationToken)
            {
                var blog = await _repository.GetBlogWithTagCloud(request.BlogId);

                var result = new GetBlogWithTagCloudQueryResult
                {
                    blogId = blog.BlogId,
                    title = blog.Title,
                    coverImageUrl= blog.CoverImageUrl,
                    description= blog.Description,
                    mainImage= blog.MainImage,
                    createdDate = blog.CreatedDate,
                    TagClouds = blog.BlogTagClouds
            .Select(btc => new TagCloudDto
            {
                TagCloudId = btc.TagCloudId,
                TagCloudTitle = btc.TagClouds.TagCloudTitle
            })
            .ToList()
                };

                return result;
            }
        }
    }
}
