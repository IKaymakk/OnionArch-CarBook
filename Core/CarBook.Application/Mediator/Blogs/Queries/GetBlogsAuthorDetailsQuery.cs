using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Blogs.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Queries
{
    public class GetBlogsAuthorDetailsQuery : IRequest<GetBlogsAuthorDetailsResult>
    {
        public int BlogId { get; set; }

        public GetBlogsAuthorDetailsQuery(int id)
        {
            BlogId = id;
        }

        public class GetBlogsAuthorDetailsQueryHandler : IRequestHandler<GetBlogsAuthorDetailsQuery, GetBlogsAuthorDetailsResult>
        {
            private readonly IBlogRepository _repository;
            IMapper _mapper;

            public GetBlogsAuthorDetailsQueryHandler(IBlogRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetBlogsAuthorDetailsResult> Handle(GetBlogsAuthorDetailsQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetBlogsAuthorDetail(request.BlogId);
                var mappedvalue = _mapper.Map<GetBlogsAuthorDetailsResult>(value);
                return mappedvalue;
            }
        }
    }
}
