using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.RentACar.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.RentACar.Queries;

public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
{
    public int LocationId { get; set; }
    public bool IsAvaible { get; set; }

    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.Location.LocationId == request.LocationId && request.IsAvaible == true);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId
            }).ToList();
        }
    }
}
