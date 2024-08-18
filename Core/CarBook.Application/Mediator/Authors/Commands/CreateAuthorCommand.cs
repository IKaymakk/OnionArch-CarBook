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
    public class CreateAuthorCommand : IRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
        {
            private readonly IRepository<Author> _repository;
            IMapper _mapper;

            public CreateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
               var mappedvalues = _mapper.Map<Author>(request);
                await _repository.CreateAsync(mappedvalues);
            }
        }
    }
}
