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
    public class GetAverageMonthlyCarPriceQuery : IRequest<GetAverageDailyCarPriceQueryResult>
    {
        public class GetAverageMonthlyCarPriceQueryHandler : IRequestHandler<GetAverageMonthlyCarPriceQuery, GetAverageDailyCarPriceQueryResult>
        {
            private readonly IStatsRepository repository;

            public GetAverageMonthlyCarPriceQueryHandler(IStatsRepository repository)
            {
                this.repository = repository;
            }

            public async Task<GetAverageDailyCarPriceQueryResult> Handle(GetAverageMonthlyCarPriceQuery request, CancellationToken cancellationToken)
            {
                var value = await repository.AverageMonthlyCarPrice();
                return new GetAverageDailyCarPriceQueryResult
                {
                    count = value
                };
            }
        }
    }
}
