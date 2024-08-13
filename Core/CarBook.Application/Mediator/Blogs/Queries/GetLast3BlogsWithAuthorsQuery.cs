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

public class GetLast3BlogsWithAuthorsQuery : IRequest<List<GetLast3BlogsWithAuthorsQueryResult>>
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        IMapper _mapper;

        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWithAuthors();
            var mappedvalues = _mapper.Map<List<GetLast3BlogsWithAuthorsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
