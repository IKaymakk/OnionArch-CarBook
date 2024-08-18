using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries
{
    public class GetLocationCountQuery : IRequest<GetLocationCountQueryResult>
    {
        public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
        {
            IRepository<Location> repository;

            public GetLocationCountQueryHandler(IRepository<Location> repository)
            {
                this.repository = repository;
            }

            public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
            {
                var values = await repository.Count();
                return new GetLocationCountQueryResult
                {
                    count = values
                };
            }
        }
    }
}
