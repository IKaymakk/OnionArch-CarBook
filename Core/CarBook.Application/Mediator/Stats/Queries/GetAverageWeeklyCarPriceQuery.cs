using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Stats.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Stats.Queries;

public class GetAverageWeeklyCarPriceQuery:IRequest<GetAverageDailyCarPriceQueryResult>
{
    public class GetAverageWeeklyCarPriceQueryHandler : IRequestHandler<GetAverageWeeklyCarPriceQuery, GetAverageDailyCarPriceQueryResult>
    {
        private readonly IStatsRepository repository;

        public GetAverageWeeklyCarPriceQueryHandler(IStatsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAverageDailyCarPriceQueryResult> Handle(GetAverageWeeklyCarPriceQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.AverageWeeklyCarPrice();
            return new GetAverageDailyCarPriceQueryResult
            {
                count = value
            };
        }
    }
}
