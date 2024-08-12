using AutoMapper;
using CarBook.Application.Inferfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Contacts.Commands
{
    public class CreateContactCommand:IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
        {
            private readonly IRepository<Contact> _repository;
            IMapper _mapper;

            public CreateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {
                var mappedvalues = _mapper.Map<Contact>(request);
                await _repository.CreateAsync(mappedvalues);

            }
        }
    }
}
