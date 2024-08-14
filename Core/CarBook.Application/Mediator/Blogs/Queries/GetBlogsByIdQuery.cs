using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Blogs.Results;
using CarBook.Domain.Entities;
using MediatR;
using System.Reflection.Metadata;

namespace CarBook.Application.Mediator.Blogs.Queries;

public class GetBlogsByIdQuery : IRequest<GetBlogsByIdQueryResult>
{
    public int id { get; set; }
    public GetBlogsByIdQuery(int id)
    {
        this.id = id;
    }


    public class GetBlogsByIdQueryHandler : IRequestHandler<GetBlogsByIdQuery, GetBlogsByIdQueryResult>
    {
        private readonly IBlogRepository _repository;
        IMapper _mapper;

        public GetBlogsByIdQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBlogsByIdQueryResult> Handle(GetBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetBlogByIdWithAuthorCategoryTagCloud(request.id);
            var mappedblog = _mapper.Map<GetBlogsByIdQueryResult>(blog);
            return new GetBlogsByIdQueryResult
            {
                BlogId = blog.BlogId,

                Title = blog.Title,
                CoverImageUrl = blog.CoverImageUrl,
                MainImage = blog.MainImage,
                CreatedDate = blog.CreatedDate,
                CategoryId = blog.Category.CategoryId,
                CategoryName = blog.Category.Name,
                Description = blog.Description,
                TagClouds = blog.BlogTagClouds.Select(tc => new TagCloudDto
                {
                    TagCloudId = tc.TagCloudId,
                    TagCloudTitle = tc.TagClouds.TagCloudTitle
                }).ToList(),
                AuthorId = blog.Author.AuthorId
            };
        }



    }
}
