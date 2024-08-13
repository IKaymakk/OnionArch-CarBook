using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Authors.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Authors.Queries;

public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryResult>>
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorsQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        IMapper _mapper;

        public GetAuthorsQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorsQueryResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetAuthorsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
