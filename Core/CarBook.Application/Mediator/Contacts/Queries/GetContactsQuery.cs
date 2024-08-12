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

namespace CarBook.Application.Mediator.Contacts.Queries;

public class GetContactsQuery:IRequest<List<GetContactsQueryResult>>
{
    public class GetContactsQueryHandler :IRequestHandler<GetContactsQuery,List<GetContactsQueryResult>>
    {
        private readonly IRepository<Contact> _repository;
        IMapper _mapper;

        public GetContactsQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactsQueryResult>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var mappedvalues = _mapper.Map<List<GetContactsQueryResult>>(values);
            return mappedvalues;
        }
    }
}
