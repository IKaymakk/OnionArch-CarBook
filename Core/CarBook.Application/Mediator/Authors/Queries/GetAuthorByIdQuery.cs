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

public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
{
    public int id { get; set; }

    public GetAuthorByIdQuery(int id)
    {
        this.id = id;
    }

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;
        IMapper _mapper;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.id);
            var mappedvalue = _mapper.Map<GetAuthorByIdQueryResult>(value);
            return mappedvalue;
        }
    }
}
