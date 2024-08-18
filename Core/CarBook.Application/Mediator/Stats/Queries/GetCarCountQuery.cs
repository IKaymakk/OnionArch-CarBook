using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries;

public class GetCarCountQuery : IRequest<GetCarCountQueryResult>
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        private readonly IRepository<Car> _repository;

        public GetCarCountQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.Count();
            return new GetCarCountQueryResult
            {
                CarCount = value
            };
        }
    }
}
