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

namespace CarBook.Application.Mediator.Stats.Queries;

public class GetBrandCountQuery : IRequest<CountQueryResult>
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, CountQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandCountQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<CountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.Count();
            return new CountQueryResult
            {
                Count = value
            };
        }
    }
}
