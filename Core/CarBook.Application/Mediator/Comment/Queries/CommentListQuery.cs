using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Comment.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Comment.Queries
{
    public class CommentListQuery:IRequest<List<CommentListQueryResult>>
    {
        public CommentListQuery(int blogid)
        {
            this.blogid = blogid;
        }

        public int blogid { get; set; }

        public class CommentListQueryHandler : IRequestHandler<CommentListQuery, List<CommentListQueryResult>>
        {
            private readonly ICommentRepository _repository;
            IMapper _mapper;

            public CommentListQueryHandler(ICommentRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<CommentListQueryResult>> Handle(CommentListQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetCommentListByBlog(request.blogid);
                var mappedvalues = _mapper.Map<List<CommentListQueryResult>>(values);
                return mappedvalues;
            }
        }
    }
}
