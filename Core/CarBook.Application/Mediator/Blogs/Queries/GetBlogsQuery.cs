using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Blogs.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Blogs.Queries;
public class GetBlogsQuery : IRequest<List<GetBlogsQueryResult>>
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        IMapper _mapper;

        public GetBlogsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogListWithAll();
            var mappedvalues = _mapper.Map<List<GetBlogsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
