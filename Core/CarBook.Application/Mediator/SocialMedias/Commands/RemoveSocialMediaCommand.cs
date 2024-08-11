using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.SocialMedias.Commands
{
    public class RemoveSocialMediaCommand:IRequest
    {
        public int id { get; set; }

        public RemoveSocialMediaCommand(int id)
        {
            this.id = id;
        }

        public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
        {
            IRepository<SocialMedia> _repository;

            public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.id);
                await _repository.RemoveAsync(value);
            }
        }
    }
}
