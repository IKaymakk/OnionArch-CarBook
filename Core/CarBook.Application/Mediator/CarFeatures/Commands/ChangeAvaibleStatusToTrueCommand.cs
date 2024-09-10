using CarBook.Application.Inferfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarFeatures.Commands
{
    public class ChangeAvaibleStatusToTrueCommand : IRequest
    {
        public int id { get; set; }
        public ChangeAvaibleStatusToTrueCommand(int id)
        {
            this.id = id;
        }
        public class ChangeAvaibleStatusToTrueCommandHandler : IRequestHandler<ChangeAvaibleStatusToTrueCommand>
        {
            private readonly ICarFeatureRepository _repository;

            public ChangeAvaibleStatusToTrueCommandHandler(ICarFeatureRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(ChangeAvaibleStatusToTrueCommand request, CancellationToken cancellationToken)
            {
                _repository.AvaibleStatusToTrue(request.id);
            }
        }
    }
}

