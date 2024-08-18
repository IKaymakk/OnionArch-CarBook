using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries;

public class GetAverageHourlyCarPriceQuery : IRequest<GetAverageDailyCarPriceQueryResult>
{
    public class GetAverageHourlyCarPriceQueryHandler : IRequestHandler<GetAverageHourlyCarPriceQuery, GetAverageDailyCarPriceQueryResult>
    {
        private readonly IStatsRepository repository;

        public GetAverageHourlyCarPriceQueryHandler(IStatsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAverageDailyCarPriceQueryResult> Handle(GetAverageHourlyCarPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.AverageHourlyCarPrice();
            return new GetAverageDailyCarPriceQueryResult
            {
                count = value
            };
        }
    }
}
