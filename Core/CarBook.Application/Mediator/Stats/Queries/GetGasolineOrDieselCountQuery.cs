using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries
{
    public class GetGasolineOrDieselCountQuery:IRequest<CountQueryResult>
    {
        public class GasolineOrDieselCountQueryHandler : IRequestHandler<GetGasolineOrDieselCountQuery, CountQueryResult>
        {
            private readonly IStatsRepository _repository;

            public GasolineOrDieselCountQueryHandler(IStatsRepository repository)
            {
                _repository = repository;
            }

            public async Task<CountQueryResult> Handle(GetGasolineOrDieselCountQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GasolineOrDieselCount();
                return new CountQueryResult { Count = value };
            }
        }
    }
}
