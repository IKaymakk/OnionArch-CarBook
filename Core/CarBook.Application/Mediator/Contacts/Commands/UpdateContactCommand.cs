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
    public class UpdateContactCommand : IRequest
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
        {
            private readonly IRepository<Contact> _contactRepository;
            IMapper _mapper;

            public UpdateContactCommandHandler(IRepository<Contact> contactRepository, IMapper mapper)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var value = await _contactRepository.GetByIdAsync(request.ContactId);
                _mapper.Map(request, value);
                await _contactRepository.UpdateAsync(value);
            }
        }
    }
}
