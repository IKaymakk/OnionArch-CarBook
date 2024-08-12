using AutoMapper;
using CarBook.Application.Inferfaces;
using CarBook.Application.Mediator.Contacts.Results;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Mediator.Contacts.Queries
{
    public class GetContactByIdQuery : IRequest<GetContactByIdQueryResult>
    {
        public int id { get; set; }

        public GetContactByIdQuery(int id)
        {
            this.id = id;
        }

        public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
        {
            private readonly IRepository<Contact> _repository;
            IMapper _mapper;

            public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetByIdAsync(request.id);
                var mappedvalue = _mapper.Map<GetContactByIdQueryResult>(value);
                return mappedvalue;
            }
        }
    }
}
