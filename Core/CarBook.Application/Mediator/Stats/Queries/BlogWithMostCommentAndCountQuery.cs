using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries
{
    public class BlogWithMostCommentAndCountQuery : IRequest<BlogWithMostCommentAndCountQueryResult>
    {
        public class BlogWithMostCommentAndCountQueryHandler : IRequestHandler<BlogWithMostCommentAndCountQuery, BlogWithMostCommentAndCountQueryResult>
        {
            private readonly IStatsRepository _repository;

            public BlogWithMostCommentAndCountQueryHandler(IStatsRepository repository)
            {
                _repository = repository;
            }

            public async Task<BlogWithMostCommentAndCountQueryResult> Handle(BlogWithMostCommentAndCountQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.BlogWithMostCommentAndCount();
                return new BlogWithMostCommentAndCountQueryResult
                {
                    Count = values.CommentCount,
                    Title = values.BlogName
                };
            }
        }
    }
}
