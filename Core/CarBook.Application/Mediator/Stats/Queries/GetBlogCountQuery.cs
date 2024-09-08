using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries;


public class GetBlogCountQuery : IRequest<CountQueryResult>
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, CountQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogCountQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<CountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.Count();
            return new CountQueryResult
            {
                Count = value
            };
        }
    }
}

