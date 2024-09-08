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
    public class GetDailyCheapestCarQuery : IRequest<GetCheapAndExpensiveCarResult>
    {
        public class GetDailyCheapestCarQueryHandler : IRequestHandler<GetDailyCheapestCarQuery, GetCheapAndExpensiveCarResult>
        {
            private readonly IStatsRepository _repository;

            public GetDailyCheapestCarQueryHandler(IStatsRepository repository)
            {
                _repository = repository;
            }

            public async Task<GetCheapAndExpensiveCarResult> Handle(GetDailyCheapestCarQuery request, CancellationToken cancellationToken)
            {
                var values = await _repository.DailyCheapestCar();
                return new GetCheapAndExpensiveCarResult
                {
                    CarName = values.Name,
                    CarBrand = values.Model,
                    Image = values.Image,
                    Price = values.Price
                };
            }
        }
    }
}
