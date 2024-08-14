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
    public class GetBlogsWithAuthorsQuery : IRequest<List<GetBlogsWithAuthorsQueryResult>>
    {
        public class GetBlogsWithAuthorsQueryHandler : IRequestHandler<GetBlogsWithAuthorsQuery, List<GetBlogsWithAuthorsQueryResult>>
        {
            private readonly IBlogRepository _repository;
            IMapper _mapper;

            public GetBlogsWithAuthorsQueryHandler(IBlogRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetBlogsWithAuthorsQueryResult>> Handle(GetBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.GetLast3BlogsWithAuthors();
                var mappedvalues = _mapper.Map<List<GetBlogsWithAuthorsQueryResult>>(values);
                return mappedvalues;
            }
        }
    }
}
