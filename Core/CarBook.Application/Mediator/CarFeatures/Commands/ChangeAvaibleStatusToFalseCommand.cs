using CarBook.Application.Inferfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.CarFeatures.Commands
{
    public class ChangeAvaibleStatusToFalseCommand:IRequest
    {
        public int id { get; set; }
        public ChangeAvaibleStatusToFalseCommand(int id)
        {
            this.id = id;
        }
        public class ChangeAvaibleStatusToFalseCommandHandler : IRequestHandler<ChangeAvaibleStatusToFalseCommand>
        {
            private readonly ICarFeatureRepository _repository;

            public ChangeAvaibleStatusToFalseCommandHandler(ICarFeatureRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(ChangeAvaibleStatusToFalseCommand request, CancellationToken cancellationToken)
            {
                _repository.AvaibleStatusToFalse(request.id);
            }
        }
    }
}
