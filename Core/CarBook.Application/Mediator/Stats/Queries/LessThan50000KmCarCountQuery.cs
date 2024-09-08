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
    public class LessThan50000KmCarCountQuery : IRequest<CountQueryResult>
    {
        public class LessThan50000KmCarCountQueryHandler : IRequestHandler<LessThan50000KmCarCountQuery, CountQueryResult>
        {
            IStatsRepository _statsRepository;

            public LessThan50000KmCarCountQueryHandler(IStatsRepository statsRepository)
            {
                _statsRepository = statsRepository;
            }

            public async Task<CountQueryResult> Handle(LessThan50000KmCarCountQuery request, CancellationToken cancellationToken)
            {
                var value = await _statsRepository.LessThan50000KmCarCount();
                return new CountQueryResult
                {
                    Count = value
                };
            }
        }
    }
}
