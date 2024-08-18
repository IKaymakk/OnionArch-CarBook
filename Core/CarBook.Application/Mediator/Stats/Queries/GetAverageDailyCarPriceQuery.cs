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
    public class GetAverageDailyCarPriceQuery : IRequest<GetAverageDailyCarPriceQueryResult>
    {
        public class GetAverageDailyCarPriceQueryHandler : IRequestHandler<GetAverageDailyCarPriceQuery, GetAverageDailyCarPriceQueryResult>
        {
            private readonly IStatsRepository _repository;

            public GetAverageDailyCarPriceQueryHandler(IStatsRepository repository)
            {
                _repository = repository;
            }

            public async Task<GetAverageDailyCarPriceQueryResult> Handle(GetAverageDailyCarPriceQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.AverageDailyCarPrice();
                return new GetAverageDailyCarPriceQueryResult
                {
                    count = values
                };
            }
        }
    }
}
