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
    public class GetBrandWithMostCarQuery : IRequest<GetBrandWithMostCarQueryResult>
    {
        public class GetBrandWithMostCarQueryHandler : IRequestHandler<GetBrandWithMostCarQuery, GetBrandWithMostCarQueryResult>
        {

            private readonly IStatsRepository _statsRepository;

            public GetBrandWithMostCarQueryHandler(IStatsRepository statsRepository)
            {
                _statsRepository = statsRepository;
            }

            public async Task<GetBrandWithMostCarQueryResult> Handle(GetBrandWithMostCarQuery request, CancellationToken cancellationToken)
            {
                var value = await _statsRepository.BrandWithMostCarAndCount();
                return new GetBrandWithMostCarQueryResult
                {
                    BrandName = value.BrandName,
                    Count = value.CarCount
                };
            }
        }
    }
}
