using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Authors.Commands
{
    public class UpdateAuthorCommand : IRequest
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }

        public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
        {
            private readonly IRepository<Author> _repository;
            IMapper _mapper;

            public UpdateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.AuthorId);
                _mapper.Map(request, value);
                await _repository.UpdateAsync(value);
            }
        }
    }
}
