using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Authors.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Authors.Queries
{
    public class GetBlogListByAuthorQuery : IRequest<List<GetBlogListByAuthorQueryResult>>
    {
        public GetBlogListByAuthorQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }

        public class GetBlogListByAuthorQueryHandler : IRequestHandler<GetBlogListByAuthorQuery, List<GetBlogListByAuthorQueryResult>>
        {
            private readonly IAuthorRepository _repository;

            public GetBlogListByAuthorQueryHandler(IAuthorRepository repository)
            {
                _repository = repository;
            }

            public async Task<List<GetBlogListByAuthorQueryResult>> Handle(GetBlogListByAuthorQuery request, CancellationToken cancellationToken)
            {
                var bloglist = await _repository.GetBlogListByAuthor(request.id);
                return bloglist.Select(blog => new GetBlogListByAuthorQueryResult
                {
                    AuthorId = blog.AuthorId,
                    BlogId = blog.BlogId,
                    CategoryName = blog.Category.Name,
                    CreatedDate = blog.CreatedDate,
                    Description = blog.Description,
                    Title = blog.Title,
                }).ToList();
            }
        }
    }
}
