using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using CarBook.Domain.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorBook.Application.Mediator.Stats.Queries
{
    public class GetAuthorCountQuery : IRequest<CountQueryResult>
    {
        public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, CountQueryResult>
        {
            private readonly IRepository<Author> _repository;

            public GetAuthorCountQueryHandler(IRepository<Author> repository)
            {
                _repository = repository;
            }

            public async Task<CountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.Count();
                return new CountQueryResult
                {
                    Count = value
                };
            }
        }
    }
}
